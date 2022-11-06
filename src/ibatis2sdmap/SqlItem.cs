using ibatis2sdmap.SqlSegments;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ibatis2sdmap;

internal class SqlItem
{
	public string Namespace { get; set; }

	public string Id { get; set; }

	public IEnumerable<SqlSegment> Segments { get; set; }

	public string Emit()
	{
		return
			$"sql {Id}\r\n" +
			"{" +
			$"{string.Concat(Segments.Select(x => x.Emit()))}\r\n" +
			"}";
	}

	public static IEnumerable<SqlItem> Create(XElement sqlMapNode)
	{
		var ns = sqlMapNode.Attribute("namespace")?.Value;
		return sqlMapNode
			.Descendants($"{{{AppConfig.NsPrefix}}}statements") // statements
			.Nodes().OfType<XElement>() // select, sql, ...
			.Select(x => new SqlItem
			{
				Id = x.Attribute("id").Value,
				Namespace = ns,
				Segments = x.Nodes().Select(SqlSegment.Create)
			});
	}
}