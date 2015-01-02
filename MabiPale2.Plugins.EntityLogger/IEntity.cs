using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MabiPale2.Plugins.EntityLogger
{
	public interface IEntity
	{
		long EntityId { get; }
		string EntityType { get; }
		string Name { get; }

		string GetInfo();
		string GetScript();
	}
}
