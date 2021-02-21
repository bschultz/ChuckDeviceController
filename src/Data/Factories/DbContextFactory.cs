﻿namespace ChuckDeviceController.Data.Factories
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

    using ChuckDeviceController.Data.Contexts;
    using ChuckDeviceController.Extensions;
    using System;

    internal static class DbContextFactory
    {
        public static DeviceControllerContext CreateDeviceControllerContext(string connectionString)// where T : DbContext
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<DeviceControllerContext>();
                //optionsBuilder.UseMySQL(connectionString);
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

                //context.ChangeTracker.AutoDetectChangesEnabled = false;
                return new DeviceControllerContext(optionsBuilder.Options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error DeviceControllerContext: {ex.Message}");
                return null;
            }
        }

        public static ValueConverter<T, string> CreateJsonValueConverter<T>()
        {
            return new ValueConverter<T, string>
            (
                v => v.ToJson(),
                v => v.FromJson<T>()
            );
        }
    }
}