Feature: Feature1

A short summary of the feature

@UITests
Scenario Outline: Skillset in EPAM search from excel
	Given I have entered the EPAM home page <Skill>
	And I have navigated to the Search panel <Record>

@source:dataSource.xlsx
Examples:
| Skill      | Record |
| Automation | 390    |