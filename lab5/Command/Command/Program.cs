using Command;
using Command.Document;
using Command.Document.Item.Paragraph;
using Command.Util;

IDocument doc = new Document(new History());
var menu = new Menu().Build(doc);
var aplication = new Application(menu);

aplication.Run();