using DotNetCoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/**
 * This is a .NET CORE web API example coded by Md Mamunur Rahman 
 * 
 * @FileName: ApplicationDbContext.cs
 * @Author Md Mamunur Rahman
 * @Phone: 6474473215
 * @website: http://mamun-portfolio.azurewebsites.net/Default.aspx
 * @Last Update 19-July-2019
 * @description: this file is DbContext clss file for the Web Api Example
 */
namespace DotNetCoreWebAPI.Context
{
    /**  
     * <summary>  
     * This is the ApplicationDbContext class extended as DbContext class to create context of memory database.  
     * </summary>  
     * @class Person
     */
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
        {

        }
    }
}
