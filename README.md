# TA-Learning

正在走技术美术学习路线，在此建仓记录，持续更新（仅按时间归档）。

## 01 [Lembert卡渲](./Lembert_ToonShader)

技美基本都要求至少熟悉一款三维引擎，初学者接触最多的无非就是UE和Unity，而UE的拟物大图标实在太丑了所以我选Unity，欸嘿。

选好了引擎熟悉完就从着色器开始吧，最开始用的还是SF连连看的方式，先抛开代码体验编着色器，在最简单的兰伯特光照模型后多连个一维UV采样就能出不错的效果，还能再加点别的“特技”，有意思。

<img src="Lembert_ToonShader/Pics/image-20210809214549029.png" alt="lambert"  />

## 02 [Screen-Door Transparency](./SDTransparency)

入坑原神以前旁观同学游玩的时候就注意到了游戏里的靠近消隐效果有点好玩，把玩了一阵子SF后就想着自个儿连个类似效果出来，虽然人家游戏里肯定不是用的这种方式实现。

<img src="SDTransparency/Pics/2021-08-10-21-15-27.gif" alt="genshin810"  />

## 03 [Phong与Bilinn-Phong](./Phong_BilinnPhong)

有了半兰伯特模型作Diffuse，还得再加点Specular，这俩就是最经典的高光模型了。

<img src="Phong_BilinnPhong/Pics/image-20210809215715099.png" alt="phong"  />

## 04 [环境吸收与投影](./AO_Shadow)

开始自己敲代码写着色器，左边是用SP烘焙好AO贴图直接采样的，右边在Fallback中调用了Unity内置支持阴影的Pass。

<img src="AO_Shadow/Pics/image-20210809220010907.png" alt="ao&shadow"  />

## 05 [法线贴图](./NormalMap)

尝试在代码中对法线贴图采样来实现假凹凸光影效果。

<img src="NormalMap/Pics/image-20210809230330461.png" alt="normalMap"  />

## 06 [CubeMap与MatCap](./CubeMap_MatCap)

CubeMap是一个立方体的六面展开图，让人惊奇的是（或者让人很不惊奇，如果你是数学大佬），从立方体中心和从球体中心向四周观察到的图像看起来是一样的，Unity中的天空盒使用的就是立方体形式。使用CubeMap的环境反射由于记录了全景环境信息所以能够跟随视角做出改变，而MatCap只存储了单个视角的反射信息看起来比较呆（但它省开销呀，根据实际情况选择吧）。

<img src="CubeMap_MatCap/Pics/2021-08-11%2010-23-20%2000_00_00-00_00_08.gif" alt="image811"  />

## 07 [经典光照模型实例](./WindWalker)

漫射、反射等光照模型与各类贴图信息的综合使用，模型和贴图资源来源于Steam上关于Dota2的某篇文章。

<img src="WindWalker/Pics/Snipaste_2021-08-12_18-25-56.png" alt="dota2-windrunner"  />

## 08 [透明中的AlphaCut、AlphaBlend与AlphaAdd](./AlphaMode)

透贴的各种模式，当然还有更多的可以自由定义，这里是庄老师讲到的常用的三种。

<img src="AlphaMode/Pics/Snipaste_2021-08-13_15-59-06.png" alt="alpha813"  />

## 09 [水与火特效](./Water_Fire)

发现游戏里类似的特效很多是靠贴图采样实现的，这就对美术资源的要求更高一些，懒得自己做贴图的话效果好不好全看手上图片资源的质量了。

<img src="Water_Fire/Pics/2021-08-13%2021-39-00.gif" alt="water&fire"  />

## 10 [背景扰动](./UVDistort)

对背景图像采样做UV扰动的结果，可以作为空气扰动或假折射效果，扰动值也可以从噪声图中采样。

<img src="UVDistort/Pics/Snipaste_2021-08-14_11-47-28.png" alt="backWarp"  />

## 11 [顶点动画](./VertexAnim)

顾名思义，在几何着色器中直接对顶点做出位移，不需要动模型本身就能实现的动画。

<img src="VertexAnim/Pics/2021-08-16-17-57-47.gif" alt="vertAnim"  />

## 12 [科幻出入场](./Cyberpunk)

前几个Demo所涉及知识点的综合运用，大半时间都花在贴图准备上了，还去入门了一下SD，果然做这行得玩转得过来一堆软件……

<img src="Cyberpunk/Pics/%E5%BA%8F%E5%88%97%2008_1.gif" alt="cyber"  />

## 13 [SSAO](./SSAO)

在蒙德接完声望任务转身上楼的时候发现凌华身上泛着一圈白光，那地方完全处在阴影之中首先排除了是Bloom，调整游戏图像设置后发现是后期效果带来的，盲猜用了SSAO，因为其中的远景吸收剔除正好会造成这个特性，不如咱自己也来实现一下。

首先照着游戏搭了个差不多的场景（AO什么的在这种犄角旮旯多的楼道最好体现了），为了观察方便顺手加个第三人称控制器。

<img src="SSAO/Pics/fpsController.gif" alt="fpsController"  />

为了场景好看一点专门烘焙了全局光照，结果为了在自定义着色器中用上光照贴图踩了不少坑，下面是烘焙好的间接光照混合直接阴影的结果。

<img src="SSAO/Pics/GI.png" alt="GI"  />

接着就是SSAO算法了，实现起来比预想的要难得多，都怪自己太菜，还好网上做知识分享的大佬多，看一下最后的效果吧。

<img src="SSAO/Pics/AO.png" alt="GI"  />

再叠加上GI看看，差不多复现了游戏里角色身上的白光晕。

<img src="SSAO/Pics/GI+AO.png" alt="GI"  />

## 14 [John Lemon's Haunted Jaunt](./JLHJ)

这是Unity官方的3D项目入门教程，玩了这么久Shader发现还没有经历过游戏的全流程开发，总感觉缺了点什么，特此体验，以后也多上上手。

<img src="JLHJ/Pics/game.png" alt="JLHJ"  />

## 15 [游戏引擎的二次开发](https://github.com/Yif1999/Pilot)

吹爆王希学长的GAMES104好吧！全程跟下了这门课和作业，给课程组准备的开源引擎框架加了postprocess、animation blending、toolchain等feature，真的算是人手一个自研引擎了。

<img src="Piccolo/Pics/image-20220515184546852.png" alt="image-20220515184546852"  />

作业达标还有毕业证书和纪念文化衫，简直不要太良心了。

## 16 [Slime Crisis](./SlimeCrisis)

在Unity交流群里看到的一个卖课的广告，首先是开展几天的免费课程完了之后搞推销，太熟悉的套路了。但是怎么说呢，还是可以白嫖一下的，花了几个晚上就做完了所谓的《史莱姆危机》小游戏（后来又打了一次广告宣发里说会带你做另一个游戏，但是一看课程目录全是一样的知识点，好家伙这也能换皮是吧）。

<img src="SlimeCrisis/Pics/0DC326DF-9AD4-41C3-9D60-DAB6442E95C0.png" alt="0DC326DF-9AD4-41C3-9D60-DAB6442E95C0"  />

课程中主要是讲C#的编码和Unity的基操，虽然说人家也不怎么解释只是直播敲敲代码然后就运行成功了，但是自己回过头好好看看的话感觉里边用到的面向对象编程的逻辑和抽象思路是值得学习的（仅限OOP新手）。

## 17 [Unity项目性能优化](https://www.bilibili.com/read/cv18188512)

性能优化总是玩家讨论时绕不开的话题，另外优化本身也很有意思，正好Unity课堂中有关于性能优化的课程索性学了起来。

<img src="Performance_Optimization/Pics/image-20221008162234782.png" alt="image-20221008162234782"  />

这里是优化最开始的截图，优化后帧率已经大幅提升。实战相关笔记文章发布在了b站专栏，可以点标题访问，目前还没有完结哦。

## 18 [Live3D](https://github.com/Yif1999/Live3D)

看到Unity官方提供了Live Capture相关的工具，想着能不能自制一个调用ARKit面部捕捉的虚拟形象应用呢——答案果然是可以的！

<img src="Live3D/Pics/2022-08-20.gif" alt="2022-08-20"  />

算是面捕重定向小测试，顺便东拼西凑实现了物理模拟等特性，属于是缝合各路大佬教程的技术验证产物。

## 19 [仿原神渲染](./GenshinAvatar)

之前做的Live3D卡渲用的是开源的ShaderGraph着色器，但要跟游戏画面比起来真的还差点意思。既然我的b站推送列表里已经人均会仿渲了，那不如就自己来实现一个吧。

<img src="GenshinAvatar/Pics/FB0BAAC4-B303-4652-AE89-036507D4B23A.png" alt="FB0BAAC4-B303-4652-AE89-036507D4B23A"  />

参考了很多前人写的渲染思路分析，不得不说米哈游在细节上是真会抠啊。另外Unity的Live Capture工具里还有提供虚拟摄像机的功能，用在虚拟制片上相当方便，那为什么不拿来用用呢。

<img src="GenshinAvatar/Pics/还是你的宵宫最可爱-动画图像（大）.gif" alt="还是你的宵宫最可爱-动画图像（大）"  />

于是就有了这个使用ARKit运动捕捉运镜的MMD成片，还额外写了天空盒Shader，实现了地面反射和粒子效果来还原角色界面。
