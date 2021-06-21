using System;

namespace ZFramework
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class BaseAttribute: Attribute
	{
		public Type AttributeType { get; }

		public BaseAttribute()
		{
			this.AttributeType = this.GetType();
		}
	}
}