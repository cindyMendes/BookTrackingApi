using System;
using System.Collections.Generic;
using BookTrackingApi.Data;
using Microsoft.EntityFrameworkCore;

namespace BookTrackingApi.Context;

public partial class BookDbContext : DbContext
{
    public BookDbContext()
    {
    }

    public BookDbContext(DbContextOptions<BookDbContext> options)
        : base(options)
    {
    }


    public DbSet<Category> Categories { get; set; }
    public DbSet<Nationality> Nationalities { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
