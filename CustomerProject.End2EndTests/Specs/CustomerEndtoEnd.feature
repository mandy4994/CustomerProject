Feature: CustomerEndtoEnd
	When I enter details and click Add Customer
	Then I am navigated to Customers List
	And I can see my Customer in the List

@mytag
Scenario: Create Customer
	Given I am on All Customers Page to count number of customers
	And I navigate Add Customer Page
	When I enter details and click Add Customer
	| FirstName | LastName | Email				| Dob		|
	| John		| Snow	   | johnsnow@gmail.com | 01Feb1993 |
	Then I can see my Customer in the List
