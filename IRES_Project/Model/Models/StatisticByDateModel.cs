﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class StatisticByDateModel
    {
        private string date;
        private float revenue;

        public string Date { get => date; set => date = value; }
        public float Revenue { get => revenue; set => revenue = value; }
    }
}
