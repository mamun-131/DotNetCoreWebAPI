using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/**
 * This is a .NET CORE web API example coded by Md Mamunur Rahman 
 * 
 * @FileName: Person.cs
 * @Author Md Mamunur Rahman
 * @Phone: 6474473215
 * @website: http://mamun-portfolio.azurewebsites.net/Default.aspx
 * @Last Update 19-July-2019
 * @description: this file is Model clss file for the Web Api Example
 */
namespace DotNetCoreWebAPI.Models
{
   /**  
    * <summary>  
    * This is the Person Model class to create the Person Object.  
    * </summary>  
    * @class Person
    */
    public class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
