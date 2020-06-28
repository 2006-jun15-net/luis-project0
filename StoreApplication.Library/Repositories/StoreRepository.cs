using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.Library.Repositories
{
    class StoreRepository
    {
        private readonly ICollection<Store> _data;

        public StoreRepository(ICollection<Store> data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }


    }
}
