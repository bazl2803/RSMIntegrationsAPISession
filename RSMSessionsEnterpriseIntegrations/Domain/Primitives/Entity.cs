﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives
{
    public abstract class Entity
    {
        public short Id { get; set; }
        public DateTime? ModifiedDate {  get; set; }
    }
}
