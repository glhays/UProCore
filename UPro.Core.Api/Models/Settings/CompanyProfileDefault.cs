// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// This source code is subject to terms and conditions set forth by UProCore
// ----------------------------------------------------------------------------------

using System;

namespace UPro.Core.Api.Models.Settings
{
    public class CompanyProfileDefault
    {
       public Guid Id { get; set; }

        public string? FirstMonthFiscalYear { get; set; }

        public string? EmployerIdentificationNumber { get; set; }

        public string? StateTaxID { get; set; }

        public int? DefaultARGL { get; set; }

        public int? DefaultARGLBank { get; set; }

        public int? DefaultAPGL { get; set; }

        public int? DefaultAPGLBank { get; set; }

        public int? DefaultPRBankAccount { get; set; }

        public int? DefaultARCreditLiability { get; set; }

        public int? DefaultInventoryGL { get; set; }

        public int? DefaultRevenueGL { get; set; }

        public DateTimeOffset? LastGLStartDate { get; set; }

        public DateTimeOffset? LastGLStopDate { get; set; }

        public string? LastGLType { get; set; }

        public string? LastPeriodClosedYear { get; set; }

        public string? LastPeriodClosedMonth { get; set; }

        public int? CurrentPeriodGLID { get; set; }

        public int? EndingInventory { get; set; }

        public bool SumAPPayments { get; set; }

        public bool SumARPayments { get; set; }

        public bool SumJE { get; set; }

        public bool SumAR { get; set; }

        public bool SumAP { get; set; }

        public Guid CompanyProfileId { get; set; }

        public CompanyProfile CompanyProfile { get; set; }

        public InventoryCostingMethod InventoryCostingMethod { get; set; }
    }
}