using System;
using System.Collections.Generic;

namespace APIBooks.Models;

public partial class Category
{
    public int Cid { get; set; }

    public string Cname { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
