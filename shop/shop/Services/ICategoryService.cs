﻿using shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Services
{
   public interface ICategoryService
    {
        IList<Category> GetCategories();
    }
}
