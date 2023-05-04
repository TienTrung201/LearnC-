use CosmeticsShop

select Products.ProductId,  Price from Products ,ProductItems
where Products.ProductId=ProductItems.ProductId
and price>100 and price<200

select * from Categories,ProductCategories,Products
where Categories.CategoryId=ProductCategories.CategoryId
and products.ProductId=ProductCategories.ProductId
and Categories.Name=N'Son Quốc tế'
select* from Products

select * from ProductCategories