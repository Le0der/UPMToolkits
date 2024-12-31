# Unity 工具合集

## 项目概述

​	**UPMToolkits** 是一个集合了多个 Unity 工具的项目，旨在帮助开发者提高生产力、简化开发流程并提供更强的定制功能。每个工具都可以单独使用，支持通过 **Unity Package Manager (UPM)** 进行安装和管理。本项目包含了以下几种类型的工具：

- 编辑器扩展工具
- 运行时功能工具
- 通用工具库

​	每个工具都包含一个独立的包，并遵循标准的 Unity 包结构。你可以在 `Packages` 文件夹中找到每个工具的完整包内容，包含了 `package.json`、运行时代码 (`Runtime/`)、编辑器扩展代码 (`Editor/`)、示例代码 (`Samples~`) 等。

### 开发版本

- **Unity 版本**：2022.3.55f1
- **适用平台**：支持所有支持 UPM 的 Unity 编辑器版本
- **版本号**：0.0.1
- **渲染管线**：通用渲染管线（Universal Render Pipeline, URP）

## 工具说明

​	该项目包含多个工具，每个工具都是一个独立的 UPM 包，可以通过 Git 或其他包管理方式进行加载。 

### 1.工程布局

```arduino
UPMToolkits/                     // 工程根目录
├── Assets/                      // 开发工程的assets目录
│   ├── ToolA/                   // 工具A（现在还没有创建的时候会具体说明）
├── ProjectSettings/             // Unity 项目设置
└── README.md                    // 本文件
```
### 2.功能说明
1. ToolA -工具的中文名称

   功能说明：为 Unity 编辑器提供更强大的界面扩展功能。
   导入链接：导入unity的git连接
### 3.工具使用

要在 Unity 项目中使用本工具合集中的工具，请按照以下步骤操作：

- 打开 Unity 项目。

- 打开 **Package Manager**，选择 **Add package from Git URL**。

- 输入工具包的 Git 地址

- 点击 **Add**，Unity 将自动下载并安装工具包。

## 创建新工具的流程

### 1. 创建工具包文件夹

​	在 `Assets/` 下创建一个新的文件夹，例如 `ToolX`，并将工具的所有内容放入其中。文件结构如下：

```arduino
<root>
  ├── package.json
  ├── README.md
  ├── CHANGELOG.md
  ├── LICENSE.md
  ├── Third Party Notices.md
  ├── Editor
  │   ├── [company-name].[package-name].Editor.asmdef
  │   └── EditorExample.cs
  ├── Runtime
  │   ├── [company-name].[package-name].asmdef
  │   └── RuntimeExample.cs
  ├── Tests
  │   ├── Editor
  │   │   ├── [company-name].[package-name].Editor.Tests.asmdef
  │   │   └── EditorExampleTest.cs
  │   └── Runtime
  │        ├── [company-name].[package-name].Tests.asmdef
  │        └── RuntimeExampleTest.cs
  ├── Samples~
  │        ├── SampleFolder1
  │        ├── SampleFolder2
  │        └── ...
  └── Documentation~
       └── [package-name].md
```

### 2.编写 `package.json` 文件

​	为工具创建一个 `package.json` 文件，放在工具包的根目录。内容类似于：

``` json
{
  "name": "com.le0der.toolx",
  "version": "1.0.0",
  "displayName": "Tool X - 新功能",
  "description": "Tool X 是一个为 Unity 编辑器提供新功能的工具。",
  "unity": "2022.3",
  "author": {
    "name": "le0der",
    "email": "le0der@163.com",
    "url": "https://le0der.top"
  },
  "dependencies": {
    "com.unity.textmeshpro": "3.0.6"
  },
  "keywords": [
    "tools",
    "unity",
    "upm"
  ],
  "license": "MIT"
}
```

### 3.实现工具功能

​	在工具包的 `Runtime/` 或 `Editor/` 文件夹中编写工具功能代码。确保根据工具的类型（运行时还是编辑器工具）将代码放置到合适的文件夹中。

- `Runtime/` 用于实现游戏运行时的功能。

- `Editor/` 用于编辑器扩展，例如自定义窗口、脚本编辑器等。

  

### 4.添加 asmdef 文件

​	如果要开发包含脚本的插件包，建议添加一个**asmdef**文件，详细信息可以查看官方文档[Unity - Manual: Assembly definitions](https://docs.unity3d.com/2022.3/Documentation/Manual/ScriptCompilationAssemblyDefinitionFiles.html)。

​	这个 asmdef 文件能将它所在的文件夹及其子文件夹的脚本打到一个独立的程序集中，表象上就是这些个脚本打到了独立的 dll 中了。

​	简单的说下 asmdef 文件的优势.

  - 更短的编译时间
  - 把"internal"访问修饰符用到了极致（要知道以往的源代码插件，因为与用户脚本编译在了同一个程序集，所以它的 Internal 修饰符并没起到应有的作用，暴露了太多，就是一个掩耳盗铃的迪米特法则罢）
  - 允许使用 unsafe code
  - .dll 文件可以指定特定的程序集引用。

### 5.测试工具功能

​	如果工具需要测试，确保在工具包中包含 `Tests/` 文件夹，并编写相关的单元测试代码。可以使用 Unity 的 **Test Framework** 来进行测试。

### 6.更新工具包信息

​	确保 `package.json` 文件中已经包含所有必要的字段，并根据工具功能的变化调整版本号（遵循语义化版本规则）。

### 7. 发布工具

​	一旦工具完成，可以将其上传到 Git 仓库并通过 Git URL 引用。也可以选择将其发布到 OpenUPM 或通过私有 npm 注册表发布。
