using System;
using System.Collections.Generic;

namespace BaseProject.Infrastructure.Models;

public partial class ElementType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Element> Elements { get; set; } = new List<Element>();
}
