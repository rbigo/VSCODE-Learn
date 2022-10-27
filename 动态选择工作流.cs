/*
Method Name : JX_SelectCategory
Creator : chenfei
Created On : 20201027
Server-side ：C#   
Item Type : Express DCO
Server Event : onAfterAdd
Comment :根据文档类型选择流程DCO流程
*/


Aras.Server.Security.Identity plmIdentity = Aras.Server.Security.Identity.GetByName("Aras PLM");
bool PermissionWasSet  = Aras.Server.Security.Permissions.GrantIdentity(plmIdentity);
//if (System.Diagnostics.Debugger.Launch())
//System.Diagnostics.Debugger.Break();
Innovator inn = this.getInnovator();
try
{
    string id=this.getID();//取得表单ID
    List<String> cls= new List<String>();
    string sql_1=" select ai.* from innovator.EXPRESS_DCO as ed inner join innovator.EXPRESS_DCO_AFFECTED_ITEM as edai on ed.ID=edai.SOURCE_ID inner join innovator.AFFECTED_ITEM as ai on edai.RELATED_ID=ai.ID where ed.ID='"+id+"'";
    Item aff=inn.applySQL(sql_1);//获取送审单中影响对象的值
    
    if(aff.getItemCount()>0){
        for(int i=0; i<aff.getItemCount();i++){
            //判断影响对象页签的操作，来取新编号或者旧编号的值
            if(aff.getItemByIndex(i).getProperty("action","")=="Add"){
                string item_id_1=aff.getItemByIndex(i).getProperty("new_item_id");
                if(string.IsNullOrEmpty(item_id_1)){
                    return inn.newError("请填写新编号！");
                    }
                string sql_ChangeCtl_1="select * from innovator.Change_Controlled_Item where id='"+item_id_1+"'";
                Item itm_ChangeCtl_1=inn.applySQL(sql_ChangeCtl_1);
                //获取具体的Change_Controlled_Item对象类
                string itmType_1=itm_ChangeCtl_1.getProperty("itemtype");
                //获取itemtype list的值（ID）
                string iType_1="innovator."+inn.getItemById("ItemType",itmType_1).getProperty("name");
                //获取具体的对象类名称；拼接innovato.
                string sql_new="select * from "+iType_1+" where id='"+item_id_1+"'";
                
                Item document=inn.applySQL(sql_new);
                //取得具体的对象
                cls.Add(document.getProperty("classification",""));
                //取得classification的值存入List列表中
                //string cls=document.getProperty("classification","");
            }else if(aff.getItemByIndex(i).getProperty("action","")=="Change"){
                string item_id_1=aff.getItemByIndex(i).getProperty("affected_id");
                if(string.IsNullOrEmpty(item_id_1)){
                    return inn.newError("请填写旧编号！");
                    }
                string sql_ChangeCtl_1="select * from innovator.Change_Controlled_Item where id='"+item_id_1+"'";
                Item itm_ChangeCtl_1=inn.applySQL(sql_ChangeCtl_1);//获取具体的Change_Controlled_Item对象类
                string itmType_1=itm_ChangeCtl_1.getProperty("itemtype");//获取itemtype list的值（ID）
                string iType_1="innovator."+inn.getItemById("ItemType",itmType_1).getProperty("name");//获取具体的对象类名称；拼接innovato.
                string sql_new="select * from "+iType_1+" where id='"+item_id_1+"'";
                
                Item document=inn.applySQL(sql_new);//取得具体的document的对象
                cls.Add(document.getProperty("classification",""));//取得classification的值存入List列表中
                //string clss=document.getProperty("classification","");
            }
            
        }
        
    }
    //判断
    string is_ok="";
    String[] str=cls.ToArray();
    //将list列表转换为数组
    //判断数组中的值是否都一致
    // return inn.newError(str.Length.ToString());
      
    //  for(int j=0;j<str.Length;j++){
    //     if(str[0]==str[j]){
    //       is_ok=str[j];
    //     }else {
    //         return inn.newError("文档类型不一致！！！");
    //     }
        
    // }
     
    //根据classification的值来确定DCO送审单的流程
    string workflowName="";
    if(! string.IsNullOrEmpty(is_ok))
    {
        if(is_ok.Contains("1 芯片/1 概念阶段/1 市场需求开发/1 市场需求报告"))
        {
            workflowName="cn_Chip design architect";
            //流程名称 芯片设计架构师--发布通知--结束
        }else if(is_ok.Contains("1 芯片/1 概念阶段/2 需求评审/1 需求评审报告"))
        {
            workflowName="cn_Marketing_project";
            //流程名称  市场部经理--项目经理--发布通知--结束
        }
        else if(is_ok.Contains("1 芯片/1 概念阶段/3 概念性方案设计/1 概念性方案"))
        {
            workflowName="cn_project";
            //流程名称 项目经理--发布通知--结束
        }
       
        else
        {
            return inn.newError("此文档无需送审！！");
        }

// return inn.newError(workflowName);
            string qty="select id  from innovator.Workflow where source_id='"+this.getID()+"'";
        	Item res=inn.applySQL(qty);
        	if(res.getItemCount()<0) 
        	{
        		Item workflow=inn.getItemByKeyedName("Workflow Map",workflowName);//return inn.newError(workflow.ToString());
        		Item workflowProcess=this.instantiateWorkflow(workflow.getID());
        		workflowProcess.startWorkflow();
        	}
    }
}
catch(Exception ex)
{
    return inn.newError("[JX_SelectCategory]:"+ex.Message);
}
finally
{
	if (PermissionWasSet) Aras.Server.Security.Permissions.RevokeIdentity(plmIdentity);
}

return this;