﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemiyNLayerProject.Core.Models;

namespace UdemiyNLayerProject.Core.Repostories
{
    interface IProductRepostory:IRepostory<Product>
    {

        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
