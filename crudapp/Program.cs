using crudapp;
using System;
using System.Data.SqlClient;
namespace crud
{
    class program
    {
        static void Main(string[] args)
        {
            Crudoperation c = new Crudoperation();
            //c.Create("create", 1, "tarun", 23, 30000, 3);
            //c.Retrive("select", "tarun",1, 23,30000, 3);
        }
    }
}