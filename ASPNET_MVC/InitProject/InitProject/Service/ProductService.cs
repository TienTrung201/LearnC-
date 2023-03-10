namespace InitProject.Models
{
    public class ProductService :List<Product>
    {
       public ProductService(){
        this.AddRange(new Product[]{
            new Product() { Id =1,Name="Iphone",Description="iphone rat manh"},
            new Product() { Id =2,Name="sam sung",Description="sam sung rat manh"},
            new Product() { Id =3,Name="nokia",Description="nokia rat manh"},
        });
       }
    }
}