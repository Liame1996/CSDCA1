Feature: Calculator

Scenario: Low Blood Pressure
	Given Systolic is 75
	And Diastolic is 50
	When the numbers are calculated
	Then the result should be Low

Scenario: Ideal Blood Pressure
	Given Systolic is 100
	And Diastolic is 70
	When the numbers are calculated
	Then the result should be Ideal

Scenario: Pre-High Blood Pressure
	Given Systolic is 130
	And Diastolic is 85
	When the numbers are calculated
	Then the result should be PreHigh

Scenario: High Blood Pressure
	Given Systolic is 160
	And Diastolic is 95
	When the numbers are calculated
	Then the result should be High
