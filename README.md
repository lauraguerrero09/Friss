#Overview
Fraud detection is a .NETCore RESTfull API, that offer 3 controllers with different endpoints that help to solve the Tecnical challenge assigned by FRISS.
1. PersonController expose a PUTAsync enpoint to store persons in an Azure table storage.
2. MatchingCalculatorController expose a Matching POST endpoint, to calculate the matching percentage between 2 persons.
3. DiminutiveController expose 2 endpoinst, PUTAsyn and GETAsyn.

#Approach:
Pattern____
1. To make easy to apply the bussiness rules, I decided to implemented a Rules Engine Pattern (https://www.pluralsight.com/courses/c-sharp-design-patterns-rules-pattern). This pattern make the code open to edition in the future if more rules are need it. 
2. The logic per each business rule is implemented in a separate class.
3. The execution of the rules are configured in a class called RuleConfigurator, this make easy to identify when a rule need to be updated if the excution order need to change. 
Similar First Name details ___
1. How to identify Diminutive?, I decided to create a table storage and save a list of diminutive for English Names(Can be done per lenguage) and compare if one of the person first name correspond to a diminutive name. Diminutive controller offer the oportunity to increase the items in the table if is need it. 
2. How to identify a possible typo in the first name?, I used the algorithm of Levenshtein(Nuget Package) that help me to identify how many characters are different between 2 names.

#Getting Started
1. Create Azure Storage Account
2. Update appsettings.json -> "StorageConnectionString"



# Friss
Techical challenge for Friss company
