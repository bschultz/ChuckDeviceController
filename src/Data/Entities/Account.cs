﻿namespace ChuckDeviceController.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using ChuckDeviceController.Data.Interfaces;

    [Table("account")]
    public class Account : BaseEntity, IAggregateRoot
    {
        [
            Column("username"),
            Key,
        ]
        public string Username { get; set; }

        [
            Column("password"),
            Required,
        ]
        public string Password { get; set; }

        [Column("first_warning_timestamp")]
        public ulong? FirstWarningTimestamp { get; set; }

        [Column("failed_timestamp")]
        public ulong? FailedTimestamp { get; set; }

        [Column("failed")]
        public string Failed { get; set; }

        [Column("level")]
        public ushort Level { get; set; }

        [Column("last_encounter_time")]
        public ulong? LastEncounterTime { get; set; }

        [Column("last_encounter_lat")]
        public double? LastEncounterLatitude { get; set; }

        [Column("last_encounter_lon")]
        public double? LastEncounterLongitude { get; set; }

        [Column("spins")]
        public uint Spins { get; set; }

        [Column("tutorial")]
        public ushort Tutorial { get; set; }
    }
}