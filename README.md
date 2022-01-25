#Overview

Fraud detection is a .NETCore RESTfull API, that offers 3 controllers with different endpoints and helps to solve the Tecnical challenge assigned.
1. PersonController expose a PUTAsync enpoint to store persons in an Azure table storage.
2. MatchingCalculatorController expose a Matching POST endpoint, to calculate the matching percentage between 2 persons.
3. DiminutiveController expose 2 endpoinst, PUTAsyn and GETAsyn.

#Approach:
Pattern____
1. To make easy to apply the bussiness rules, I decided to implemented a Rules Engine Pattern (https://www.pluralsight.com/courses/c-sharp-design-patterns-rules-pattern). This pattern make the code open to edition in the future if more rules are need it. 
2. The logic per each business rule is implemented in a separate class.
3. The execution of the rules are configured in a class called RuleConfigurator, this make easy to identify when a rule needs to be updated or if the excution order needs to be changed.

Storage____
1. I decided to use table storage to have a quick connection and implementation.
2. As the Identification number will be unknown and we can have a lot of entities with different data combinations I preferred to use a no relation database. 
3. Id is need to the storage can be query based on the bussiness logic rule(FirstName, LastName, DateOfBirth ... etc).
4. Easy to scale.

Similar First Name details ___
1. How to identify Diminutive?, I decided to create a table storage and save a list of diminutive for English Names(Can be done per lenguage) and compare if one of the person first name correspond to a diminutive name. Diminutive controller offer the oportunity to increase the items in the table if is need it. 
2. How to identify a possible typo in the first name?, I used the algorithm of Levenshtein(Nuget Package) that help me to identify how many characters are different between 2 names.

#Unit test and code coverage:
1. Controllers and bussiness logic were covered by unit test, to avoid side effect in future code edition.
2. The code has 68.92% of coverage focused on business rules and controllers:
  ![image](https://user-images.githubusercontent.com/27976372/150950611-f33a753b-7fb8-470d-a664-87ab051244ae.png)
    
#Getting Started
1. Create Azure Storage Account
2. Update appsettings.json -> "StorageConnectionString"
3. To execute the endpoints you have 2 options:
    - Swagger UI: https://localhost:44302/swagger/index.html
    - Postman collection:/PostmanCollection
4. To load the diminutives in the table storage, use the postman collection(Diminutive PUT) and with a runner tab select the .cvs file diminutive. Location /DiminutiveData

#Things to improve:
1. Instead of receiving 2 persons in the Matching endpoint, receive only one and compare with the information in Person Table Storage.
2. Create and enpoint to set the RuleConfigurator order.
3. Include catche and login.
4. Create a generic table storage service.

