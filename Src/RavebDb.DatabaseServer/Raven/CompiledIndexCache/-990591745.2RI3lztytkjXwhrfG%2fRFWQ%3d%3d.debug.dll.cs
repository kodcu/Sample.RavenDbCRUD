using Raven.Abstractions;
using Raven.Database.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;
using Raven.Database.Linq.PrivateExtensions;
using Lucene.Net.Documents;
using System.Globalization;
using System.Text.RegularExpressions;
using Raven.Database.Indexing;


public class Index_Auto_2fPeople_2fByAddresses_City : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Auto_2fPeople_2fByAddresses_City()
	{
		this.ViewText = @"from doc in docs.People
from docAddressesItem in ((IEnumerable<dynamic>)doc.Addresses).DefaultIfEmpty()
select new { Addresses_City = docAddressesItem.City }";
		this.ForEntityNames.Add("People");
		this.AddMapDefinition(docs => 
			from doc in docs
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "People", System.StringComparison.InvariantCultureIgnoreCase)
			from docAddressesItem in ((IEnumerable<dynamic>)doc.Addresses).DefaultIfEmpty()
			select new {
				Addresses_City = docAddressesItem.City,
				__document_id = doc.__document_id
			});
		this.AddField("Addresses_City");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("City");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("City");
		this.AddQueryParameterForReduce("__document_id");
	}
}
