﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Customer//her musterının bır ısı olmalı dıye job tablosu eklendı
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string City { get; set; }
		public int JobId { get; set; }
		public Job Job { get; set; }//bire cok ilişki kurulsun diye buraya bınlar yazıldı
	}
}
