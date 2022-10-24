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
bool PermissionWasSet = Aras.Server.Security.Permissions.GrantIdentity(plmIdentity);
Innovator inn = this.getInnovator();
try
{
    string id = this.getID(); //取得表单ID
    List<String> cls = new List<String>();
    string sql_1 =
        " select ai.* from innovator.EXPRESS_DCO as ed inner join innovator.EXPRESS_DCO_AFFECTED_ITEM as edai on ed.ID=edai.SOURCE_ID inner join innovator.AFFECTED_ITEM as ai on edai.RELATED_ID=ai.ID where ed.ID='"
        + id
        + "'";
    Item aff = inn.applySQL(sql_1); //获取送审单中影响对象的值

    if (aff.getItemCount() > 0)
    {
        for (int i = 0; i < aff.getItemCount(); i++)
        {
            //判断影响对象页签的操作，来取新编号或者旧编号的值
            if (aff.getItemByIndex(i).getProperty("action", "") == "Add")
            {
                string item_id_1 = aff.getItemByIndex(i).getProperty("new_item_id");
                if (string.IsNullOrEmpty(item_id_1))
                {
                    return inn.newError("请填写新编号！");
                }
                string sql_ChangeCtl_1 =
                    "select * from innovator.Change_Controlled_Item where id='" + item_id_1 + "'";
                Item itm_ChangeCtl_1 = inn.applySQL(sql_ChangeCtl_1); //获取具体的Change_Controlled_Item对象类
                string itmType_1 = itm_ChangeCtl_1.getProperty("itemtype"); //获取itemtype list的值（ID）
                string iType_1 =
                    "innovator." + inn.getItemById("ItemType", itmType_1).getProperty("name"); //获取具体的对象类名称；拼接innovato.
                string sql_new = "select * from " + iType_1 + " where id='" + item_id_1 + "'";

                Item document = inn.applySQL(sql_new); //取得具体的对象
                cls.Add(document.getProperty("classification", "")); //取得classification的值存入List列表中
                //string cls=document.getProperty("classification","");
            }
            else if (aff.getItemByIndex(i).getProperty("action", "") == "Change")
            {
                string item_id_1 = aff.getItemByIndex(i).getProperty("affected_id");
                if (string.IsNullOrEmpty(item_id_1))
                {
                    return inn.newError("请填写旧编号！");
                }
                string sql_ChangeCtl_1 =
                    "select * from innovator.Change_Controlled_Item where id='" + item_id_1 + "'";
                Item itm_ChangeCtl_1 = inn.applySQL(sql_ChangeCtl_1); //获取具体的Change_Controlled_Item对象类
                string itmType_1 = itm_ChangeCtl_1.getProperty("itemtype"); //获取itemtype list的值（ID）
                string iType_1 =
                    "innovator." + inn.getItemById("ItemType", itmType_1).getProperty("name"); //获取具体的对象类名称；拼接innovato.
                string sql_new = "select * from " + iType_1 + " where id='" + item_id_1 + "'";

                Item document = inn.applySQL(sql_new); //取得具体的document的对象
                cls.Add(document.getProperty("classification", "")); //取得classification的值存入List列表中
                //string clss=document.getProperty("classification","");
            }
        }
    }
    //判断
    string is_ok = "";
    String[] str = cls.ToArray(); //将list列表转换为数组
    //判断数组中的值是否都一致
    // return inn.newError(str.Length.ToString());
    for (int j = 0; j < str.Length; j++)
    {
        if (str[0] == str[j])
        {
            is_ok = str[j];
        }
        else
        {
            return inn.newError("文档类型不一致！！！");
        }
    }

{"1 芯片/2 计划阶段/2 产品规格制定/1 产品规格书","2","3","4","5","6","7","8","9","10","11","12","13",}
    //根据classification的值来确定DCO送审单的流程
    string workflowName = "";
    if (!string.IsNullOrEmpty(is_ok))
    {
        if (is_ok.Contains("1 研发/1 立项阶段(L)/市场调研信息记录表"))
        {
            return inn.newError("此类别文档暂无流程！");
        }
        else if (is_ok.Contains("1 研发/1 立项阶段(L)/立项建议书"))
        {
            workflowName = "DCO_2"; //流程名称
        }
        else if (is_ok.Contains("1 研发/1 立项阶段(L)/合同评审表"))
        {
            workflowName = "DCO_3"; //流程名称
        }
        else if (is_ok.Contains("1 研发/1 立项阶段(L)/设计可行性报告"))
        {
            workflowName = "DCO_4"; //流程名称
        }
        else if (is_ok.Contains("1 研发/1 立项阶段(L)/成本可行性报告"))
        {
            return inn.newError("此类别文档暂无流程！");
        }
        else if (is_ok.Contains("1 研发/1 立项阶段(L)/项目立项评审表"))
        {
            workflowName = "DCO_6"; //流程名称
        }
        else if (is_ok.Contains("1 研发/1 立项阶段(L)/立项申请批示单"))
        {
            workflowName = "DCO_7"; //流程名称
        }
        else if (is_ok.Contains("1 研发/2 策划阶段(C)/设计开发策划/质量保证大纲"))
        {
            workflowName = "DCO_8"; //流程名称
        }
        else if (is_ok.Contains("1 研发/2 策划阶段(C)/设计开发策划/风险管理计划"))
        {
            workflowName = "DCO_9"; //流程名称
        }
        else if (is_ok.Contains("1 研发/2 策划阶段(C)/设计开发策划/标准化大纲"))
        {
            workflowName = "DCO_10"; //流程名称
        }
        else if (is_ok.Contains("1 研发/2 策划阶段(C)/设计开发策划/产品六性大纲"))
        {
            workflowName = "DCO_11"; //流程名称
        }
        else if (is_ok.Contains("1 研发/2 策划阶段(C)/设计开发策划/设计开发风险清单"))
        {
            workflowName = "DCO_12"; //流程名称
        }
        else if (is_ok.Contains("1 研发/2 策划阶段(C)/设计开发策划/参考网表（反向）"))
        {
            workflowName = "DCO_13"; //流程名称
        }
        else if (is_ok.Contains("1 研发/2 策划阶段(C)/设计开发策划/参考网表照片（反向）"))
        {
            workflowName = "DCO_14"; //流程名称
        }
        else if (is_ok.Contains("1 研发/2 策划阶段(C)/设计开发策划/设计、验证、仿真环境"))
        {
            workflowName = "DCO_15"; //流程名称
        }
        else if (is_ok.Contains("1 研发/2 策划阶段(C)/设计开发策划/设计、验证、仿真环境说明文件"))
        {
            workflowName = "DCO_16"; //流程名称
        }
        else if (is_ok.Contains("1 研发/2 策划阶段(C)/设计开发策划/IP需求申请单"))
        {
            workflowName = "DCO_17"; //流程名称
        }
        else if (is_ok.Contains("1 研发/2 策划阶段(C)/设计开发策划/IP的相关初始数据、资料"))
        {
            workflowName = "DCO_18"; //流程名称
        }
        else if (is_ok.Contains("1 研发/2 策划阶段(C)/设计开发策划/工艺需求单"))
        {
            workflowName = "DCO_19"; //流程名称
        }
        else if (is_ok.Contains("1 研发/2 策划阶段(C)/设计开发策划/工艺相关文件"))
        {
            workflowName = "DCO_20"; //流程名称
        }
        else if (is_ok.Contains("1 研发/2 策划阶段(C)/设计开发策划/整理后的前仿真初始网表（数字）（反向）"))
        {
            workflowName = "DCO_21"; //流程名称
        }
        else if (is_ok.Contains("1 研发/2 策划阶段(C)/设计开发策划/整理后的顶层前仿真初始网表（模拟）（反向）"))
        {
            workflowName = "DCO_22"; //流程名称
        }
        else if (is_ok.Contains("1 研发/2 策划阶段(C)/设计开发策划/定制参考网表（反向）（如有）"))
        {
            workflowName = "DCO_23"; //流程名称
        }
        else if (is_ok.Contains("1 研发/2 策划阶段(C)/设计开发策划/策划阶段评审报告"))
        {
            workflowName = "DCO_24"; //流程名称
        }
        else if (is_ok.Contains("1 研发/2 策划阶段(C)/设计开发策划/设计输入文件清单"))
        {
            workflowName = "DCO_25"; //流程名称
        }
        else if (is_ok.Contains("1 研发/2 策划阶段(C)/设计开发策划/设计输入评审报告"))
        {
            workflowName = "DCO_26"; //流程名称
        }
        else if (is_ok.Contains("1 研发/2 策划阶段(C)/设计开发策划/设计开发计划"))
        {
            workflowName = "DCO_27"; //流程名称
        }
        else if (is_ok.Contains("1 研发/2 策划阶段(C)/设计开发策划/技术状态管理计划"))
        {
            workflowName = "DCO_28"; //流程名称
        }
        else if (is_ok.Contains("1 研发/2 策划阶段(C)/设计开发策划/转阶段风险评估报告"))
        {
            workflowName = "DCO_29"; //流程名称
        }
        else if (is_ok.Contains("1 研发/2 策划阶段(C)/设计开发策划/技术状态文件清单"))
        {
            workflowName = "DCO_30"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/方案设计/总体设计方案"))
        {
            workflowName = "DCO_31"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/方案设计/设计方案评审报告"))
        {
            workflowName = "DCO_32"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/方案设计/特性分析报告"))
        {
            workflowName = "DCO_33"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/产品规范（详细规范或数据手册）"))
        {
            workflowName = "DCO_34"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/测试规范"))
        {
            workflowName = "DCO_35"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/设计和测试软件清单"))
        {
            return inn.newError("此类别文档暂无流程！");
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/设计和测试软件确认表"))
        {
            workflowName = "DCO_37"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/数模接口数据"))
        {
            workflowName = "DCO_38"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/数模接口说明文档"))
        {
            workflowName = "DCO_39"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/数字电路定型前仿真网表"))
        {
            workflowName = "DCO_40"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/模拟电路定型前仿真网表（电路）"))
        {
            workflowName = "DCO_41"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/数字各模块前仿设计、验证报告"))
        {
            workflowName = "DCO_42"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/数字各模块前仿设计、验证报告（报告说明文件）"))
        {
            workflowName = "DCO_43"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/模拟模块设计前仿真报告"))
        {
            workflowName = "DCO_44"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/模拟模块的前仿真说明"))
        {
            workflowName = "DCO_46"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/数字后端指导手册（前后端交接的说明文档）"))
        {
            workflowName = "DCO_47"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/模拟版图指导手册（模拟前端工程师交接的说明文档）"))
        {
            workflowName = "DCO_48"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/IP说明（文档）"))
        {
            workflowName = "DCO_49"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/参考网表仿真报告（反向）-外设"))
        {
            workflowName = "DCO_50"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/参考网表仿真报告（反向）-整体"))
        {
            workflowName = "DCO_51"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/定制参考网表仿真报告（反向）"))
        {
            workflowName = "DCO_52"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/网表（综合后网表）"))
        {
            workflowName = "DCO_54"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/约束文件"))
        {
            workflowName = "DCO_55"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/综合过程报告（数据）"))
        {
            workflowName = "DCO_56"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/综合设计报告（文档）"))
        {
            workflowName = "DCO_57"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/PR版图数据、网表（数字）"))
        {
            workflowName = "DCO_58"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/PR后SDF文件"))
        {
            workflowName = "DCO_59"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/PR报告（数据）"))
        {
            workflowName = "DCO_60"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/模拟版图验证报告（数据）"))
        {
            workflowName = "DCO_61"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/后仿真寄生参数文件（模拟）"))
        {
            workflowName = "DCO_62"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/数字PR设计报告（文档）"))
        {
            workflowName = "DCO_63"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/模拟版图设计报告（文档）"))
        {
            workflowName = "DCO_64"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/对应工艺库路径"))
        {
            workflowName = "DCO_65"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/布局布线报告"))
        {
            workflowName = "DCO_66"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/PR后仿真报告（数字）"))
        {
            workflowName = "DCO_67"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/后仿真报告（模拟）"))
        {
            workflowName = "DCO_68"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/数字后仿真设计报告（文档）"))
        {
            workflowName = "DCO_69"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/模拟后仿真设计报告（文档）"))
        {
            workflowName = "DCO_70"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/全芯片GDS"))
        {
            workflowName = "DCO_71"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/芯片整体网表"))
        {
            workflowName = "DCO_72"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/定制电路原理图"))
        {
            workflowName = "DCO_73"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/定制单元前仿真报告"))
        {
            workflowName = "DCO_74"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/定制单元GDS"))
        {
            workflowName = "DCO_75"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/定制单元后仿真报告"))
        {
            workflowName = "DCO_76"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/验证报告（DRC,LVS,ERC...）"))
        {
            workflowName = "DCO_77"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/详细设计文件存放路径清单"))
        {
            workflowName = "DCO_78"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/新品封装申请表"))
        {
            workflowName = "DCO_79"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/产品封装技术说明"))
        {
            workflowName = "DCO_80"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/新品封装评审表"))
        {
            workflowName = "DCO_81"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/设计检查清单"))
        {
            workflowName = "DCO_82"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/首件产品测试方案"))
        {
            workflowName = "DCO_83"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/转阶段风险评估报告"))
        {
            workflowName = "DCO_84"; //流程名称
        }
        else if (is_ok.Contains("1 研发/3 设计开发阶段(S)/详细设计（含初样仿真）/设计评审报告（流片前评审）"))
        {
            workflowName = "DCO_85"; //流程名称
        }
        else if (is_ok.Contains("1 研发/4 工程阶段(G)/试制阶段/试制前准备状态检查表"))
        {
            workflowName = "DCO_86"; //流程名称
        }
        else if (is_ok.Contains("1 研发/4 工程阶段(G)/试制阶段/数据拷出申请表"))
        {
            workflowName = "DCO_87"; //流程名称
        }
        else if (is_ok.Contains("1 研发/4 工程阶段(G)/试制阶段/新品流片进度表"))
        {
            return inn.newError("此类别文档暂无流程！");
        }
        else if (is_ok.Contains("1 研发/4 工程阶段(G)/试制阶段/PCM参数(Fab厂提供）"))
        {
            return inn.newError("此类别文档暂无流程！");
        }
        else if (is_ok.Contains("1 研发/4 工程阶段(G)/试制阶段/圆片测试报告"))
        {
            workflowName = "DCO_90"; //流程名称
        }
        else if (is_ok.Contains("1 研发/4 工程阶段(G)/试制阶段/晶圆封装委托单"))
        {
            workflowName = "DCO_91"; //流程名称
        }
        else if (is_ok.Contains("1 研发/4 工程阶段(G)/试制阶段/成品测试报告"))
        {
            workflowName = "DCO_92"; //流程名称
        }
        else if (is_ok.Contains("1 研发/4 工程阶段(G)/试制阶段/ESD测试报告"))
        {
            workflowName = "DCO_93"; //流程名称
        }
        else if (is_ok.Contains("1 研发/4 工程阶段(G)/试制阶段/抗闩锁测试报告"))
        {
            workflowName = "DCO_94"; //流程名称
        }
        else if (is_ok.Contains("1 研发/4 工程阶段(G)/试制阶段/电路送样反馈单"))
        {
            workflowName = "DCO_95"; //流程名称
        }
        else if (is_ok.Contains("1 研发/4 工程阶段(G)/试制阶段/工程批总结报告"))
        {
            workflowName = "DCO_96"; //流程名称
        }
        else if (is_ok.Contains("1 研发/4 工程阶段(G)/试制阶段/首件测试报告（首件鉴定）"))
        {
            workflowName = "DCO_97"; //流程名称
        }
        else if (is_ok.Contains("1 研发/4 工程阶段(G)/试制阶段/转阶段风险评估报告"))
        {
            workflowName = "DCO_98"; //流程名称
        }
        else if (is_ok.Contains("1 研发/4 工程阶段(G)/试制阶段/产品质量评审报告（工程批）"))
        {
            workflowName = "DCO_99"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/改版报告"))
        {
            workflowName = "DCO_100"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/改版数据清单"))
        {
            return inn.newError("此类别文档暂无流程！");
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/设计更改评审单"))
        {
            workflowName = "DCO_102"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/工程批转小批量审批表"))
        {
            workflowName = "DCO_103"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/测试程序"))
        {
            workflowName = "DCO_104"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/测试程序评审报告"))
        {
            workflowName = "DCO_105"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/试验大纲"))
        {
            workflowName = "DCO_106"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/首件测试大纲"))
        {
            workflowName = "DCO_107"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/晶圆测试大纲"))
        {
            workflowName = "DCO_108"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/成品测试大纲"))
        {
            workflowName = "DCO_109"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/ADC模块试验大纲"))
        {
            workflowName = "DCO_110"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/军品筛选试验大纲"))
        {
            workflowName = "DCO_111"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/入厂检验大纲"))
        {
            workflowName = "DCO_112"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/出厂检验大纲"))
        {
            workflowName = "DCO_113"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/PCM验收规范"))
        {
            workflowName = "DCO_114"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/小批量总结"))
        {
            workflowName = "DCO_115"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/小批量转量产审批表"))
        {
            workflowName = "DCO_116"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/数据手册"))
        {
            workflowName = "DCO_117"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/电路开发总结"))
        {
            workflowName = "DCO_118"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/报废申请批准单"))
        {
            workflowName = "DCO_119"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/量产总结"))
        {
            workflowName = "DCO_120"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/风险管理报告"))
        {
            workflowName = "DCO_121"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/标准化审查报告"))
        {
            workflowName = "DCO_122"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/产品六性设计报告"))
        {
            workflowName = "DCO_123"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/质量保证报告"))
        {
            workflowName = "DCO_124"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/技术状态审查报告"))
        {
            workflowName = "DCO_125"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/测试报告"))
        {
            workflowName = "DCO_126"; //流程名称
        }
        else if (is_ok.Contains("1 研发/5 定型阶段(D)/正样阶段/研制总结报告"))
        {
            workflowName = "DCO_127"; //流程名称
        }
        else if (is_ok.Contains("2 应用/1 立项阶段(L)/立项建议书（含市场可行性内容）"))
        {
            workflowName = "DCO_128"; //流程名称
        }
        else if (is_ok.Contains("2 应用/1 立项阶段(L)/项目可行性报告（技术、成本等）"))
        {
            workflowName = "DCO_129"; //流程名称
        }
        else if (is_ok.Contains("2 应用/1 立项阶段(L)/立项申请批示单"))
        {
            workflowName = "DCO_130"; //流程名称
        }
        else if (is_ok.Contains("2 应用/2 策划阶段(C)/方案设计/设计开发计划"))
        {
            workflowName = "DCO_131"; //流程名称
        }
        else if (is_ok.Contains("2 应用/2 策划阶段(C)/方案设计/产品功能规格书以及总体设计方案"))
        {
            workflowName = "DCO_132"; //流程名称
        }
        else if (is_ok.Contains("2 应用/2 策划阶段(C)/方案设计/规格书及设计方案评审报告"))
        {
            workflowName = "DCO_133"; //流程名称
        }
        else if (is_ok.Contains("2 应用/3 工程阶段(G)/详细设计/原理图、pcb、BOM等硬件资料"))
        {
            workflowName = "DCO_134"; //流程名称
        }
        else if (is_ok.Contains("2 应用/3 工程阶段(G)/详细设计/软件源、烧录文件"))
        {
            workflowName = "DCO_135"; //流程名称
        }
        else if (is_ok.Contains("2 应用/4 定型阶段(D)/正样阶段/产品应用说明"))
        {
            workflowName = "DCO_136"; //流程名称
        }
        else if (is_ok.Contains("2 应用/4 定型阶段(D)/正样阶段/验证测试报告"))
        {
            workflowName = "DCO_137"; //流程名称
        }
        else if (is_ok.Contains("2 应用/4 定型阶段(D)/正样阶段/项目总结报告"))
        {
            workflowName = "DCO_138"; //流程名称
        }
        else if (is_ok.Contains("2 应用/4 定型阶段(D)/正样阶段/项目结项验收报告"))
        {
            workflowName = "DCO_139"; //流程名称
        }
        else
        {
            return inn.newError("此文档无需送审！！");
        }

        // return inn.newError(workflowName);
        string qty = "select id  from innovator.Workflow where source_id='" + this.getID() + "'";
        Item res = inn.applySQL(qty);
        if (res.getItemCount() < 0)
        {
            Item workflow = inn.getItemByKeyedName("Workflow Map", workflowName); //return inn.newError(workflow.ToString());
            Item workflowProcess = this.instantiateWorkflow(workflow.getID());
            workflowProcess.startWorkflow();
        }
    }
}
catch (Exception ex)
{
    return inn.newError("[JX_SelectCategory]:" + ex.Message);
}
finally
{
    if (PermissionWasSet)
        Aras.Server.Security.Permissions.RevokeIdentity(plmIdentity);
}

return this;

