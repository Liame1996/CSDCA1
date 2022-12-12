import {check, sleep } from "k6";
import http from "k6/http";

//will all congfig during k6 test execution
export let options = {

  //point to 20 virtual users over one min, keep them there for one min
  //reduce to zero over a min to test the load.  
  stages: [
    { duration: "1m", target: 20 },
    { duration: "1m", target: 20 },
    { duration: "1m", target: 0 }

  ],
  
  // The threshold is set to be 95%
  // if the response time excceds 95% then the test will fail
        thresholds: {
    "http_req_duration": ["p(95) < 200"]
  },

  // discarding all saved bodies of HTTP for improved experience
  discardResponseBodies: false,

  ext: {
    loadimpact: {
        
        //check distribution from a zone
        distribution: {
          loadZoneID: { loadZone: "amazon:ie:dublin", percent: 100}

        }
    }
  }
};

// create a function that will generate a randome int
function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1) + min);
}
  
  // Export a default function - this will be the start point into the VMs
  export default function() {
   
    let bpcal = http.get("https://bp-calculator-stage.azurewebsites.net", {"responseType": "text"});
  
    // cookies automatically handled i.e. cookies sent by server will be re-presented by the client in all subsequent requests
    // until end of script
  
    check(bpcal, {
      "is status 200": (r) => r.status === 200
    });
  
    //POST random data so there is no server cached response
    bpcal = bpcal.submitForm({
      fields: { SystId: getRandomInt(80, 130).toString(), DiasId: getRandomInt(40, 100).toString() }
    });
  
    check(bpcal, {
      "is status 200": (r) => r.status === 200
    });
  
    // sleep for 3 seconds
    sleep(3);
  }