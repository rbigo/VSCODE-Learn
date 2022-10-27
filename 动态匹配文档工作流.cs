var classification_1= new[] {"1 芯片/2 计划阶段/2 产品规格制定/1 产品规格书"};
var classification_2 = new[] {"1 芯片/1 概念阶段/2 需求评审/1 需求评审报告","1 芯片/1 概念阶段/3 概念性方案设计/1 概念性方案"};
var classification_3 = new[] {"1 芯片/2 计划阶段/5 架构设计评审/1 架构评审报告","1 芯片/2 计划阶段/3 规格评审/1 产品规格评审报告","1 芯片/2 计划阶段/4 架构设计/1 DFMEA","1 芯片/2 计划阶段/4 架构设计/3 Chip spec","1 芯片/2 计划阶段/4 架构设计/4 特殊特性清单","1 芯片/2 计划阶段/4 架构设计/5 项目开发计划","1 芯片/2 计划阶段/4 架构设计/6 产品研制任务书","1 芯片/2 计划阶段/4 架构设计/7 产品质量保证大纲","1 芯片/2 计划阶段/4 架构设计/8 产品通用质量特性大纲","1 芯片/2 计划阶段/4 架构设计/9 产品技术状态管理计划","1 芯片/2 计划阶段/4 架构设计/10 设计与开发输入情单","1 芯片/3 开发阶段/20 物理设计评审/1 评审报告","1 芯片/3 开发阶段/23 芯片流片前最终设计验证评审/1 评审报告"};
var classification_4 = new[] {"1 芯片/3 开发阶段/19 物理设计/1 时序约束文件","1 芯片/3 开发阶段/19 物理设计/2 功耗约束文件","1 芯片/3 开发阶段/19 物理设计/3 芯片管脚特性和分布表格","1 芯片/3 开发阶段/19 物理设计/4 片上存储资源列表","1 芯片/3 开发阶段/19 物理设计/5 硬核IP信息","1 芯片/3 开发阶段/19 物理设计/6 可靠性设计方案"};
var classification_5 = new[] {"1 芯片/3 开发阶段/1 模块设计/1 模块设计工作手册","1 芯片/3 开发阶段/2 模块设计评审/1 模块设计评审报告","1 芯片/3 开发阶段/6 模块设计代码评审/1 评审报告","1 芯片/3 开发阶段/11 FPGA原型验证方案/1 芯片测试方案","1 芯片/3 开发阶段/12 FPGA原型验证方案评审/1 评审报告"};
var classification_6 = new[] {"1 芯片/2 计划阶段/4 架构设计/2 芯片验证策略"};
var classification_7 = new[] {"1 芯片/3 开发阶段/3 模块验证方案/1 模块验证方案","1 芯片/3 开发阶段/4 模块验证方案评审/1 模块验证方案评审报告","1 芯片/3 开发阶段/5 模块验证代码评审/1 评审报告","1 芯片/3 开发阶段/7 模块验证/1 模块验证报告","1 芯片/3 开发阶段/8 模块验证评审/1 评审报告","1 芯片/3 开发阶段/9 集成验证/1 集成验证报告","1 芯片/3 开发阶段/10 集成验证评审/1 评审报告"};
var classification_8 = new[] {"2 软件/1 需求阶段/2 需求分析/1 需求评审报告","2 软件/1 需求阶段/2 需求分析/2 PRD","2 软件/2 规划阶段/1 架构设计/1 软件架构设计","2 软件/2 规划阶段/2 架构评审/1 架构设计评审报告","2 软件/3 设计阶段/1 模块设计/1 软件模块设计","2 软件/3 设计阶段/2 模块评审/1 模块设计评审报告","2 软件/4 实现阶段/1 代码编;写/1 软件产品代码","2 软件/4 实现阶段/1 代码编写/2 代码静态分析报告"};
待定，暂时不管-----{"","","","","","","","","","","","",""};
var classification_10 = new[] {"1 芯片/3 开发阶段/15 固件开发方案/1 固件开发方案","1 芯片/3 开发阶段/16 固件开发方案评审/1 固件开发方案评审报告","1 芯片/3 开发阶段/17 固件代码评审/1 固件代码评审报告","1 芯片/3 开发阶段/18 固件测试评审/1 固件测试评审报告","1 芯片/3 开发阶段/13 FPGA原型验证/1 测试代码(固件开发工程师优选）","1 芯片/3 开发阶段/14 FPGA原型验证评审/1 评审报告(固件开发工程师优选）"};
var classification_11 = new[] {"1 芯片/4 验证阶段/1 芯片流片/1 流片样件","1 芯片/5 发布阶段/1 产品开发总结/1 研制总结报告"};
var classification_12 = new[] {"2 软件/1 需求阶段/1 需求发现/1 MRD","2 软件/1 需求阶段/1 需求发现/2 CRD","1 芯片/1 概念阶段/1 市场需求开发/1 市场需求报告"};
var classification_13 = new[] {"2 软件/1 需求阶段/3. 立项/1. 立项任务书"};
var classification_14 = new[] {"1 芯片/4 验证阶段/5 小批量生产/1 生产计划","1 芯片/4 验证阶段/5 小批量生产/3 生产总结","1 芯片/4 验证阶段/6 批量评审/1 评审报告"};
var classification_15 = new[] {"1 芯片/3 开发阶段/21 PCB设计/1 PCB layout","1 芯片/3 开发阶段/22 PCB设计评审/1 评审报告"};
var classification_16 = new[] {"1 芯片/5 发布阶段/3 产品发布/3 培训记录"};
var classification_17 = new[] {"1 芯片/4 验证阶段/2 PCB制造/1 PCB样件"};
var classification_18 = new[] {"1 芯片/5 发布阶段/3 产品发布/1 芯片数据手册","1 芯片/5 发布阶段/3 产品发布/2 芯片性能使用指南"};
var classification_19 = new[] {"1 芯片/5 发布阶段/1 产品开发总结/2 项目总结报告","1 芯片/5 发布阶段/2 结项/"};
var classification_20 = new[] {"1 芯片/1 概念阶段/4 立项评审/1 可行性分析报告","1 芯片/1 概念阶段/4 立项评审/2 立项任务书","1 芯片/1 概念阶段/4 立项评审/3 项目人员清单","1 芯片/2 计划阶段/1 立项会议/1 会议记录"};
var classification_21 = new[] {"2 软件/1 需求阶段/3. 立项/2. 项目人员清单"};
var classification_22 = new[] {"2 软件/2 规划阶段/1 架构设计/2 软件项目计划"};
{"1 芯片/3 开发阶段/13 FPGA原型验证/1 测试代码(软件开发工程师优选）","1 芯片/3 开发阶段/14 FPGA原型验证评审/1 评审报告(软件开发工程师优选）"};
var classification_24 = new[] {"1 芯片/4 验证阶段/3 芯片测试/1 芯片测试报告","1 芯片/4 验证阶段/4 测试评审/1 评审报告","1 芯片/4 验证阶段/5 小批量生产/2 测试报告"};
var classification_25 = new[] {"2 软件/3 设计阶段/1 模块设计/2 软件测试计划","2 软件/4 实现阶段/1 代码编写/1.测试用例","2 软件/4 实现阶段/2 代码测试/2.测试脚本","2 软件/4 实现阶段/2 代码测试/2 模块测试报告","2 软件/5 测试阶段/1 集成回归测试/1 集成测试报告","2 软件/5 测试阶段/1 集成回归测试/2 回归测试报告","2 软件/5 测试阶段/2 测试评审/1 测试评审报告","2 软件/6 发布阶段/1 版本发布/1 软件发布包","2 软件/6 发布阶段/1 版本发布/2 软件发布清单","2 软件/6 发布阶段/1 版本发布/3 版本维护计划"};
var classification_26 = new[] {"2 软件/6 发布阶段/1 版本发布/4 开发回顾报告"};

        
     
if(classification_1.Any(ClassStr.Contains))
{workflowName ="wx_Architecture designer -- R&D director -- Project manager";}
else if(classification_2.Any(ClassStr.Contains))
{workflowName ="wx_Architecture designer - R&D director - R&D deputy general manager";}
else if(classification_3.Any(ClassStr.Contains))
{workflowName ="wx_Chip design architect -- general technical director -- project manager";}
else if(classification_4.Any(ClassStr.Contains))
{workflowName ="wx_Chip design engineer -- chip design director -- general technical director";}
else if(classification_5.Any(ClassStr.Contains))
{workflowName ="wx_Chip Design Engineer -- Module Design Director -- General Technical Director";}
else if(classification_6.Any(ClassStr.Contains))
{workflowName ="wx_Chip verification architect -- general technical director -- project manager";}
else if(classification_7.Any(ClassStr.Contains))
{workflowName ="wx_Chip verification engineer -- module verification leader -- general technical leader";}
else if(classification_8.Any(ClassStr.Contains))
{workflowName ="wx_Development engineer -- R&D manager -- R&D director";}
else if(classification_9.Any(ClassStr.Contains))
{workflowName ="wx_Firmware development engineer -- firmware development leader -- general technical leader";}
else if(classification_10.Any(ClassStr.Contains))
{workflowName ="wx_Firmware development engineer -- firmware principal -- general technical principal";}
else if(classification_11.Any(ClassStr.Contains))
{workflowName ="wx_General technical director -- project manager -- CEO";}
else if(classification_12.Any(ClassStr.Contains))
{workflowName ="wx_Marketing Manager -- Marketing Director -- COO";}
else if(classification_13.Any(ClassStr.Contains))
{workflowName ="wx_Marketing Manager - R&D Director";}
else if(classification_14.Any(ClassStr.Contains))
{workflowName ="wx_Planning specialist -- Project manager -- CEO";}
else if(classification_15.Any(ClassStr.Contains))
{workflowName ="wx_Product engineer -- general technical director -- project manager";}
else if(classification_16.Any(ClassStr.Contains))
{workflowName ="wx_Product engineer -- Marketing director -- COO";}
else if(classification_17.Any(ClassStr.Contains))
{workflowName ="wx_Product engineer -- project manager -- CEO";}
else if(classification_18.Any(ClassStr.Contains))
{workflowName ="wx_Product engineer -- Test director -- Technical director";}
else if(classification_19.Any(ClassStr.Contains))
{workflowName ="wx_Project manager -- COO -- CEO";}
else if(classification_20.Any(ClassStr.Contains))
{workflowName ="wx_Project Manager -- Deputy General Manager -- General Manager ";}
else if(classification_21.Any(ClassStr.Contains))
{workflowName ="wx_Project Manager - R&D Director - CEO";}
else if(classification_22.Any(ClassStr.Contains))
{workflowName ="wx_Project Manager -- R&D Manager -- R&D Director";}
else if(classification_23.Any(ClassStr.Contains))
{workflowName ="wx_Software development engineer -- software development director -- general technical director";}
else if(classification_24.Any(ClassStr.Contains))
{workflowName ="wx_Test engineer -- test director -- general technical director ";}
else if(classification_25.Any(ClassStr.Contains))
{workflowName ="wx_Test engineer -- Test manager -- R&D director";}
else if(classification_26.Any(ClassStr.Contains))
{workflowName ="wx_doc_project_manage";}


else if(classification_1.Contains(DocClassifition))
{workflowName ="wx_Architecture designer -- R&D director -- Project manager";}
else if(classification_2.Contains(DocClassifition))
{workflowName ="wx_Architecture designer - R&D director - R&D deputy general manager";}
else if(classification_3.Contains(DocClassifition))
{workflowName ="wx_Chip design architect -- general technical director -- project manager";}
else if(classification_4.Contains(DocClassifition))
{workflowName ="wx_Chip design engineer -- chip design director -- general technical director";}
else if(classification_5.Contains(DocClassifition))
{workflowName ="wx_Chip Design Engineer -- Module Design Director -- General Technical Director";}
else if(classification_6.Contains(DocClassifition))
{workflowName ="wx_Chip verification architect -- general technical director -- project manager ";}
else if(classification_7.Contains(DocClassifition))
{workflowName ="wx_Chip verification engineer -- module verification leader -- general technical leader ";}
else if(classification_8.Contains(DocClassifition))
{workflowName ="wx_Development engineer -- R&D manager -- R&D director";}
else if(classification_9.Contains(DocClassifition))
{workflowName ="wx_Firmware development engineer -- firmware development leader -- general technical leader";}
else if(classification_10.Contains(DocClassifition))
{workflowName ="wx_Firmware development engineer -- firmware principal -- general technical principal";}
else if(classification_11.Contains(DocClassifition))
{workflowName ="wx_General technical director -- project manager -- CEO";}
else if(classification_12.Contains(DocClassifition))
{workflowName ="wx_Marketing Manager -- Marketing Director -- COO";}
else if(classification_13.Contains(DocClassifition))
{workflowName ="wx_Marketing Manager - R&D Director";}
else if(classification_14.Contains(DocClassifition))
{workflowName ="wx_Planning specialist -- Project manager -- CEO";}
else if(classification_15.Contains(DocClassifition))
{workflowName ="wx_Product engineer -- general technical director -- project manager";}
else if(classification_16.Contains(DocClassifition))
{workflowName ="wx_Product engineer -- Marketing director -- COO";}
else if(classification_17.Contains(DocClassifition))
{workflowName ="wx_Product engineer -- project manager -- CEO ";}
else if(classification_18.Contains(DocClassifition))
{workflowName ="wx_Product engineer -- Test director -- Technical director";}
else if(classification_19.Contains(DocClassifition))
{workflowName ="wx_Project manager -- COO -- CEO ";}
else if(classification_20.Contains(DocClassifition))
{workflowName ="wx_Project Manager -- Deputy General Manager -- General Manager ";}
else if(classification_21.Contains(DocClassifition))
{workflowName ="wx_Project Manager - R&D Director - CEO";}
else if(classification_22.Contains(DocClassifition))
{workflowName ="wx_Project Manager -- R&D Manager -- R&D Director";}
else if(classification_23.Contains(DocClassifition))
{workflowName ="wx_Software development engineer -- software development director -- general technical director ";}
else if(classification_24.Contains(DocClassifition))
{workflowName ="wx_Test engineer -- test director -- general technical director ";}
else if(classification_25.Contains(DocClassifition))
{workflowName ="wx_Test engineer -- Test manager -- R&D director";}
else if(classification_26.Contains(DocClassifition))
{workflowName ="wx_doc_project_manage";}

