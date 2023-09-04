using System;
using System.Collections.Generic;

namespace APIBooks.Models;

public partial class Book
{
    public int Bid { get; set; }

    public string BookName { get; set; } = null!;

    public int? BookCategory { get; set; }

    public string Author { get; set; } = null!;

    public double? Price { get; set; }

    public virtual Category? BookCategoryNavigation { get; set; }
}
