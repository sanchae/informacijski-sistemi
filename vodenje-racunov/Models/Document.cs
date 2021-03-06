﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace vodenje_racunov.Models
{
    public class Document
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocumentId { get; set; }
        [Display(Name = "Stranka")]
        public Client Client { get; set; }
        [Required]
        [Display(Name = "Stranka")]
        public int ClientId { get; set; }


        //predračun
        [Display(Name = "Datum predračuna")]
        public DateTime? OfferDate { get; set; }

        public string OfferDateString
        {
            get
            {
                if (this.OfferDate.HasValue)
                {
                    return this.OfferDate.Value.ToString("dd.MM.yyyy");
                }
                return string.Empty;
            }
        }

        [Display(Name = "Veljavnost dni")]
        public int? OfferValidityDays { get; set; }

        [Display(Name = "Datum naročila")]
        public DateTime? OfferDateOfOrder { get; set; }
        public string OfferDateOfOrderString
        {
            get
            {
                if (this.OfferDateOfOrder.HasValue)
                {
                    return this.OfferDateOfOrder.Value.ToString("dd.MM.yyyy");
                }
                return string.Empty;
            }
        }

        //račun
        [Display(Name = "Datum računa")]
        public DateTime? InvoiceDate { get; set; }
        public string InvoiceDateString
        {
            get
            {
                if (this.InvoiceDate.HasValue)
                {
                    return this.InvoiceDate.Value.ToString("dd.MM.yyyy");
                }
                return string.Empty;
            }
        }

        [Display(Name = "Datum opravljene storitve od:")]
        public DateTime? InvoiceServiceFrom { get; set; }
        public string InvoiceServiceFromString
        {
            get
            {
                if (this.InvoiceServiceFrom.HasValue)
                {
                    return this.InvoiceServiceFrom.Value.ToString("dd.MM.yyyy");
                }
                return string.Empty;
            }
        }

        [Display(Name = "Datum opravljene storitve do:")]
        public DateTime? InvoiceServiceUntil { get; set; }
        public string InvoiceServiceUntilString
        {
            get
            {
                if (this.InvoiceServiceUntil.HasValue)
                {
                    return this.InvoiceServiceUntil.Value.ToString("dd.MM.yyyy");
                }
                return string.Empty;
            }
        }

        [Display(Name = "Datum zapadlosti")]
        public DateTime? InvoiceDateOfMaturity { get; set; }
        public string InvoiceDateOfMaturityString
        {
            get
            {
                if (this.InvoiceDateOfMaturity.HasValue)
                {
                    return this.InvoiceDateOfMaturity.Value.ToString("dd.MM.yyyy");
                }
                return string.Empty;
            }
        }

        [Display(Name = "Datum naročila")]
        public DateTime? InvoiceDateOfOrder { get; set; }
        public string InvoiceDateOfOrderString
        {
            get
            {
                if (this.InvoiceDateOfOrder.HasValue)
                {
                    return this.InvoiceDateOfOrder.Value.ToString("dd.MM.yyyy");
                }
                return string.Empty;
            }
        }

        //dobavnica
        [Display(Name = "Datum dobavnice")]
        public DateTime? DeliveryNoteDate { get; set; }
        public string DeliveryNoteDateString
        {
            get
            {
                if (this.DeliveryNoteDate.HasValue)
                {
                    return this.DeliveryNoteDate.Value.ToString("dd.MM.yyyy");
                }
                return string.Empty;
            }
        }

        //cene
        [Display(Name = "Skupaj brez DDV")]
        public decimal? TotalExcludingVAT { get; set; }

        [Display(Name = "Popust v %")]
        public decimal? DiscountPercent { get; set; }

        [Display(Name = "Popust v €")]
        public decimal? DiscountAmount { get; set; }

        [Display(Name = "Znesek brez DDV")]
        public decimal? AmountExcludingVAT { get; set; }

        [Display(Name = "Skupaj z DDV")]
        public decimal? AmountIncludingVAT { get; set; }
        

        [Display(Name = "Montaža")]
        public decimal? AssemblyPrice { get; set; }

        //status
        public decimal? PaidAmount { get; set; } //za prikaz v tabeli, koliko % je plačano
 
    }
}