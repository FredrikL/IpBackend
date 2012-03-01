SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[entries](
	[ip] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[updated] [datetime] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[entries] ADD  CONSTRAINT [DF_entries_updated]  DEFAULT (getdate()) FOR [updated]
GO


