using System;

using HackForGood.Models;

namespace HackForGood.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Photo Item { get; set; }
        public ItemDetailViewModel(Photo item = null)
        {
            Title = item?.Description;
            Item = item;
        }
    }
}
