//Created by Rehan - 081295955149
using System;

namespace A1.Models
{
    public class a1data
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string footer { get; set; }
        //Kuncinya di sini harus di kasih nilai null kalau tdk muncul nilai date yg salah.
        public Nullable<DateTime> createdAt { get; set; }   //tambahan validasi kalau field createdAt-nya gak ada hrs di null kan.
    }
}