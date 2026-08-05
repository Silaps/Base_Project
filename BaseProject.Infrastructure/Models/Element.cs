using System;
using System.Collections.Generic;

namespace BaseProject.Infrastructure.Models;

public partial class Element
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ElementTypeId { get; set; }

    public virtual ElementType ElementType { get; set; } = null!;
}
