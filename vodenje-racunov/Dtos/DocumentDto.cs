using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using vodenje_racunov.Models;

namespace vodenje_racunov.Dtos
{
    public class DocumentDto
    {
        public int DocumentId { get; set; }
        public ClientDto Client { get; set; }
        public int ClientId { get; set; }

        //predračun
        public DateTime? OfferDate { get; set; }
        public int? OfferValidityDays { get; set; }
        public DateTime? OfferDateOfOrder { get; set; }

        //račun
        public DateTime? InvoiceDate { get; set; }
        public DateTime? InvoiceServiceFrom { get; set; }
        public DateTime? InvoiceServiceUntil { get; set; }
        public DateTime? InvoiceDateOfMaturity { get; set; }
        public DateTime? InvoiceDateOfOrder { get; set; }

        //dobavnica
        public DateTime? DeliveryNoteDate { get; set; }

        //cene
        public decimal? TotalExcludingVAT { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? AmountExcludingVAT { get; set; }
        public decimal? AmountIncludingVAT { get; set; }

        //status
        public decimal? PaidAmount { get; set; }
        public decimal? AssemblyPrice { get; set; }

    }
}