﻿using Api.Dev.Middleware.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Api.Dev.Middleware.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Clinic> Clinics {get;set;}
        public DbSet<Staff> Staff { get; set; }
    }
}
