USE [FoodRecipes]
GO

/****** Object:  Table [dbo].[Recipes]    Script Date: 6/18/2021 10:21:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Recipes](
	[RecipeID] [int] IDENTITY(1,1) NOT NULL,
	[RecipeName] [nvarchar](50) NOT NULL,
	[Recipe] [nvarchar](max) NOT NULL,
	[Duration] [nvarchar](20) NOT NULL,
	[Image] [image] NOT NULL,
	[Descriptions] [nvarchar](200) NOT NULL,
	[Servings] [int] NOT NULL,
	[Facts] [nvarchar](250) NOT NULL,
	[RecipeCategoryID] [int] NOT NULL,
	[Bookmarks] [bit] NOT NULL,
 CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED 
(
	[RecipeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Recipes]  WITH CHECK ADD  CONSTRAINT [FK_Recipes_RecipeCategories] FOREIGN KEY([RecipeCategoryID])
REFERENCES [dbo].[RecipeCategories] ([RecipeCategoryID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Recipes] CHECK CONSTRAINT [FK_Recipes_RecipeCategories]
GO


