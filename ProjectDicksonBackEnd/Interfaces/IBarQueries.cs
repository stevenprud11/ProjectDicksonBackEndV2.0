﻿using System.Collections.Generic;
using ProjectDicksonBackEnd.Models;

namespace ProjectDicksonBackEnd.Repository
{
    public interface IBarQueries
    {
        public List<Bar> GetBars();
        public List<Bar> GetBars(string barName);
        public List<Bar> SearchBarLocation(string location);
    }
}