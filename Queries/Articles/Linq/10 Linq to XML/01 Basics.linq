<Query Kind="Statements">
  <Namespace>System.Xml.Linq</Namespace>
</Query>

// String Parsing
XElement el = XElement.Parse(@"<Portfolio>
  <!-- Some Options -->
  <Option K='100' Exp='2019-01-01' />
  <Strategy>
  	<Option K='110' Exp='2019-01-01' />
  	<Option K='100' Exp='2020-01-01' />
  </Strategy>
   <Strategy>
  	<Option K='210' Exp='2019-01-01' />
  	<Option K='200' Exp='2020-01-01' />
  </Strategy>
</Portfolio>");

// Code Composition
new XElement("Portfolio",
		new XElement("Option", new XAttribute("Strike","100"), new XAttribute("Exp","2019-01-01")))
		.Dump("Code Composition");
		
// Functional Composition
new XElement("Portfolio",
	from exp in new[] { "2019-01-01", "2020-01-01"}
	from k in new[] {100,100}
	select new XElement("Option",new XAttribute("K",k), new XAttribute("Exp",exp)))
	.Dump("Functional Composition");
	
// First Node
el.FirstNode.Dump("FirstNode");

// Last Node
el.LastNode.Dump("LastNode");

// Nodes
el.Nodes().Dump("Nodes");

// Elements
el.Elements().Dump("Elements");

// Alternative Elements
el.Nodes().OfType<XElement>().Dump("Alternative Elements");

// SelectMany
(from strategy in el.Elements("Strategy")
from option in strategy.Elements("Option")
select option).Dump("Select Many");

// Elements<IEnumerable<XContainer>
IEnumerable<XElement> strategies = el.Elements("Strategy");
strategies.Elements("Option").Dump("Elements(<IEnumerable<XContainer>)");

// Element
el.Element("Strategy").Dump("Element");

// Alternative Element
el.Elements("Strategy").FirstOrDefault().Dump("Alternative Element");

// Null Elements
el.Element("Missing")?.Value.Dump("Null Elements");

// Descendents
el.Descendants().Select(e => e.Name).Dump("Descendants");

// Descendents(String)
el.Descendants("Option").Select(e => e.Name).Dump("Descendants(String)");

// Parent
var op = el.Element("Strategy").Element("Option");
op.Parent.Dump("Parent");

// Ancestors
op.Ancestors().Select(o => o.Name).Dump("Ancestors");

// Ancestors(string)
op.Ancestors("Portfolio").Select(o => o.Name).Dump("Ancestors(string)");

// AncestorsAndSelf
op.AncestorsAndSelf().Select(o => o.Name).Dump("AncestorsAndSelf");

// IsBefore
var last = el.Elements("Strategy").Last().Element("Option");
last.IsBefore(op).Dump("IsBefore");

// IsBefore
last.IsAfter(op).Dump("IsAfter");

// NexNode at this level
op.NextNode.Dump("NextNode");

// PreviousNode at this level. 
op.PreviousNode.Dump("PreviousNode");

// NodesAfterSelf
el.FirstNode.NodesAfterSelf().Select(fn => fn.GetType()).Dump("NodesAfterSelf");

// NodesBeforeSelf
el.FirstNode.NodesBeforeSelf().Select(fn => fn.GetType()).Dump("NodesBeforeSelf");

// ElementsAfterSelf
el.FirstNode.ElementsAfterSelf().Select(e=>e.Name).Dump("ElementsAfterSelf");

// ElementsBeforeSelf
el.FirstNode.ElementsBeforeSelf().Select(e => e.Name).Dump("ElementsBeforeSelf");

// ElementsAfterSelf(string)
el.FirstNode.ElementsAfterSelf("Strategy").Select(e => e.Name).Dump("ElementsAfterSelf(string)");

// ElementsBeforeSelf(string)
el.FirstNode.ElementsBeforeSelf("Option").Select(e => e.Name).Dump("ElementsBeforeSelf(string)");

// HasAttributes
el.HasAttributes.Dump("HasAttributes");

// Attribute
el.Element("Option").Attribute("K").Dump("Attribute");

// LastAttribute
el.Element("Option").LastAttribute.Dump("LastAttribute");

// Attributes
el.Element("Option").Attributes().Dump("Attributes");