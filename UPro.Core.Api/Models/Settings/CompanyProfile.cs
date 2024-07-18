// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// This source code is subject to terms and conditions set forth by UProCore
// ----------------------------------------------------------------------------------

using System;

namespace UPro.Core.Api.Models.Settings
{
    public class CompanyProfile
    {
        public Guid Id { get; set; }

        public string CompanyName { get; set; }

        public string? FictitiousBusinessName { get; set; }

        public string Address1 { get; set; }

        public string? Address2 { get; set; }

        public string? Address3 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Telephone { get; set; }

        public string? TelephoneAlternate { get; set; }

        public string? EmailAddress { get; set; }

        public byte[] CompanyLogo { get; set; }

        public string? CompanyLogoPath { get; set; }

        public CompanyProfileDefault? ProfileDefaults { get; set; }
    }
}