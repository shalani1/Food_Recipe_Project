USE [FoodRecipes]
GO

/****** Object:  Table [dbo].[RecipeCategories]    Script Date: 6/18/2021 10:19:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RecipeCategories](
	[RecipeCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[RecipeCategoryName] [nvarchar](50) NOT NULL,
	[Image] [image] NOT NULL,
 CONSTRAINT [PK_RecipeCategories] PRIMARY KEY CLUSTERED 
(
	[RecipeCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


