using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class FirstPage:PageModel
{
     public void OnGet( int? solan){// lấy ra solan handler trang web
          if(solan!=null){
               ViewData["tientrung"]=$"Nguyễn Tiến Trung{solan.Value}";
          }
         
    }public void OnGetXyz(){
         ViewData["tientrung"]="hello ...";
    }
    public void OnGetXyzk(){
         ViewData["tientrung"]="Con bò";
    }
    public string title {set;get;}= "day la trang dau tien hahaa";
    public Func<string,string> welcome =(name)=>"xin chao "+ name;
}