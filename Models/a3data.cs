//Created by Rehan - 081295955149
using System;
using System.Collections.Generic;

namespace A3.Models
{
    public class items
    {
        public string title { get; set; }
        public string description { get; set; }
        public string footer { get; set; }
    }

    public class a3data
    {
        public int id { get; set; }
        public int category { get; set; }        
        public List<items> Items { get; set; }
        //Kuncinya di sini harus di kasih nilai null kalau tdk muncul nilai date yg salah.
        public Nullable<DateTime> createdAt { get; set; }   //tambahan validasi kalau field createdAt-nya gak ada hrs di null kan.
    }
}