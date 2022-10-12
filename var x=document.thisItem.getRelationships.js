var x=document.thisItem.getRelationships("Express DCO Affected Item")
var y=x.getItemByIndex(0).getRelatedItem()
var z=y.getProperty("new_item_id")
var xx=aras.IomInnovator.newItem("Change Controlled Item","get");
xx.setID(z)
var zz=xx.apply()
var zzz=zz.getProperty("cn_project")
var xmjh=aras.IomInnovator.newItem("project","get");
xmjh.setID(zzz)
var xmjss=xmjh.apply()
xmjss.fetchRelationships("Project Team")
var qwer=xmjss.getRelationships("Project Team")
qwer.getItemByIndex(0).getProperty("role")
var aaa=qwer.getItemByIndex(0).getProperty("role")
var bbb=aras.IomInnovator.newItem("value","get")
bbb.setProperty("value",aaa)
bbb.setProperty("source_id","E15C81B361CB44F09508F9259D1C5B5D")
var ccc=bbb.apply()
ccc.getProperty("label")
qwer.getItemByIndex(0).getRelatedItem().getID



var AffectedItem=this.getRelationships("Batch Part")
var RelatedItem=AffectedItem.getItemByIndex(0).getRelatedItem()
var partId=RelatedItem.getProperty("id")


var inn = top.Innovator();
var classification='';
setTimeout(function() {
    debugger;
    classification = document.thisItem.getProperty('classification');
    document.querySelector("input[name='name']").value=classification;
}, 1000);

var inn = top.Innovator();
var classification='';
setTimeout(function() {
    debugger;
    classification = document.thisItem.getProperty('classification');
    this.setProperty("name",classification);
    document.querySelector("input[name='name']").value=classification;
}, 1000);



