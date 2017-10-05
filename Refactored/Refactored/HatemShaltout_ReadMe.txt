Hatem Shaltout - 06/10/2017

Thank You for giving me this opportunity.

- I used VS 2017 for newer version and technology, though I understand that VS 2005 is preferrable, 
but the instructions also said: make your changes to this project to make it better.

- I updated the Nuget packages

- I kept the existing project for reference

- I Used Postman on Chrome browser to test the api

- I followed the MVC architecture to have models and controllers.
	* First I created a single model for both tables
	* I Added two controllers to build the methods
	* I started using the Options Controller into the Products Controller and adding further functional logic

- Further enhancements/features could include
	* Additional parameter checks that could be inserted to ensure data validation and integrity
	* More exception handling specifically validating the data format and types before and after triggering the db 
	* Adding a log to keep track of errors and exceptions 
	* More restrictive routing to prevent unnecessary data being commmunicated in or out
	* Adding an authentication method to enhance security and limit user/data access
	* Remove Unused packages and references

- There are routing problems I couldn't resolve:
	* 3 (GET /products/{id}) since it conflicts with the (GET /products/{id}/options). 
	* 10 (PUT /products/{id}/options/{optionId}) since it conflicts with the (PUT /products/{id}).
	* 11 (DELETE /products/{id}/options/{optionId}) since it conflicts with the (DELETE /products/{id}).

	I have tried reordering the routing maps and tried more restrictive routing with the RouteConfig.cs 
	but received more trouble when going that path.

1. GET /products
public IQueryable<Product> GetProducts()
	Description: Does not require any input and Returns all products and is called using the default 'Products' Controller

2. GET /products?name={name}
public IHttpActionResult GetProductName(string name)
    Description: Takes a Product name as input and Returns all products that equal the searched name.
	Enhancements: Usually these names can exclude certain common keywords to increase matching results. 
	Validation: Checks if string matches records and returns records otherwise returns 404 not found

 3. GET /products/{id}
 public IHttpActionResult GetProduct(Guid id)
	Description: Takes a Product Guid as input and Returns all products that match the primary key id
	Validation: Checks if string matches records and returns records otherwise returns 404 not found

 4. POST /products
public IHttpActionResult PostProduct(Product product)
    Description: Takes a product object as input to add new record and returns a 201 Created. 
	Validation: Checks for Model is Valid and If record already exists otherwise returns bad request

 5. PUT /products/{id}
public IHttpActionResult PutProduct(Guid id, Product product)
    Description: Takes a GUID and product object as input to update an existing record and returns a 204 No Content. 
	Validation: Checks for Model is Valid, Matching Existing Product ID otherwise returns bad request and checks for DBConcurrency Exception.

 6. DELETE /products/{id}
public IHttpActionResult DeleteProduct(Guid id)
    Description: Takes a GUID as input to delete an existing record and returns a 200 Ok. 
	Validation: Checks for existing record and removes from db otherwise if record not found returns 404 not found
        
 7. GET /products/{id}/options
public IHttpActionResult GetProductOptions(Guid id)
  	Description: Takes a Product Guid as input and Returns all Options that match the product key id
	Validation: Checks if id matches records and returns records otherwise returns 404 not found
      
 8. GET /products/{id}/options/{optionId}
 public IHttpActionResult GetProductOptionsID(Guid id, Guid optionid)
   	Description: Takes a Product Guid and Option GUID as input and Returns all Options that match the product and options id
	Validation: Checks if id matches records and returns records otherwise returns 404 not found
        
 9. POST /products/{id}/options
 public IHttpActionResult PostProductOption(Guid id, ProductOption productOption)
    Description: Takes a Product Guid and Option object as input to add new options record with matching Existing Product ID 
	then adds the record and returns a 201 Created. 
    Validation: Checks for Model is Valid and if Product ID match records otherwise returns 404 not found
	
 10. PUT /products/{id}/options/{optionId}
 public IHttpActionResult PutProductOption(Guid productid, Guid optionid, ProductOption productOption)
    Description: Takes a Product GUID, Option Guid and Option object as input to add update existing options record and returns a 200 Ok. 
	Validation: Checks for Model is Valid and if Product ID and Option ID match records otherwise returns 404 not found
	    
 11. DELETE /products/{id}/options/{optionId}
 public IHttpActionResult DeleteProductOption(Guid id)
    Description: Takes a product GUID and Option Guid as inputs to delete all existing records and returns a 200 Ok. Retrieves the existing record and checks if its exists then removes from db.
    Validation: Checks for Model is Valid and if Product ID and Option ID match records otherwise returns 404 not found
	