using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ucu.Poo.Defense
{
    public class Offer
    {
        public double Total
        {
            get
            {
                double total = 0;
                foreach (OfferItem item in this.items)
                {
                    total = total + item.SubTotal;
                }

                return total;
            }
        }
        public DateTime EndDate { get; set; }

        public IReadOnlyCollection<OfferItem> Items
        {
            get
            {
                return new ReadOnlyCollection<OfferItem>(this.items);
            }
        }

        private IList<OfferItem> items = new List<OfferItem>();

        public Offer(DateTime endDate)
        {
            this.EndDate = endDate;
        }

        public void AddItem(OfferItem item)
        {
            this.items.Add(item);
        }

        public void RemoveItem(OfferItem item)
        {
            this.items.Remove(item);
        }

        public string AsText()
        {
            string text = $"Fecha: {this.EndDate}\n";
            foreach (OfferItem item in this.items)
            {
                text = text + $"{item.Quantity} de '{item.Residue.Name}' " +
                $"a {item.Price}\n";
            }
            text = text + $"Total: ${this.Total}";
            return text;
        }
    }
}