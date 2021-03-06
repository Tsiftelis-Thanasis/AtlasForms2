USE [atlas]
GO
/****** Object:  StoredProcedure [dbo].[GetWeeklyReportStat1All]    Script Date: 7/7/2017 2:35:15 πμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetWeeklyReportStat1All]
	@kid int
AS
BEGIN

declare @currentdate as date = cast('01/06/2017' as date)

declare @startdate as date, @enddate as date

select @startdate = 
(case when DATEPART(WEEKDAY, @currentdate) = 1 then DATEADD(DAY,-2,@currentdate) 
when DATEPART(WEEKDAY, @currentdate) = 2 then DATEADD(DAY,-3,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 3 then DATEADD(DAY,-4,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 4 then DATEADD(DAY,-5,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 5 then DATEADD(DAY,-6,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 6 then DATEADD(DAY,0,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 7 then DATEADD(DAY,-1,@currentdate)
end )

select @enddate = 
(case when DATEPART(WEEKDAY, @currentdate) = 1 then DATEADD(DAY,4,@currentdate) 
when DATEPART(WEEKDAY, @currentdate) = 2 then DATEADD(DAY,3,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 3 then DATEADD(DAY,2,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 4 then DATEADD(DAY,1,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 5 then DATEADD(DAY,0,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 6 then DATEADD(DAY,6,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 7 then DATEADD(DAY,5,@currentdate)
end )


select top 5 vw.*, p1.PlayerPhoto from (
		SELECT ROW_NUMBER() OVER(order by isnull(cast(sum(ps.ptstotal)as numeric),0) desc) AS Row,   
		p.LastName +', '+p.FirstName thisname, playerid thisid, 
		s.SeasonName, d.DiorganwshName, o.OmilosName, 
		k.KathgoriaName, k.Id KathgoriaId,
		t.teamname, t.id teamId,
		isnull(cast(sum(ps.ptstotal)as numeric),0) totalpoints
		from dbo.PlayersStatisticsTable ps
		inner join dbo.PlayersTable p on ps.Playerid = p.id 
		inner join dbo.GamesTable g on ps.Gameid = g.id
		inner join dbo.SeasonTable s on s.id = g.Seasonid
		inner join dbo.DiorganwshTable d on d.Id = g.Diorganwshid
		inner join dbo.OmilosTable o on o.Id = g.Omilosid
		inner join dbo.KathgoriesTable k on k.id = g.Kathgoriaid
		inner join dbo.TeamsStatisticsTable ts on ts.id = ps.teamstatisticsid and ts.Gameid = g.Id
		inner join dbo.TeamsTable t on t.id = ts.Teamid
		where 1=1 		and (k.id = @kid or @kid=0)
		and cast(g.gamedate as date) between @startdate and @enddate
		group by p.LastName +', '+ p.FirstName, ps.playerid, 
		s.SeasonName, d.DiorganwshName, o.OmilosName, k.KathgoriaName, k.Id, t.teamname, t.id) as vw
		inner join dbo.playerstable p1 on vw.thisid = p1.id
	order by vw.totalpoints desc
	
end


USE [atlas]
GO
/****** Object:  StoredProcedure [dbo].[GetWeeklyReportStat2All]    Script Date: 7/7/2017 2:35:20 πμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetWeeklyReportStat2All]
	@kid int
AS
BEGIN

declare @currentdate as date =  cast('01/06/2017' as date)

declare @startdate as date, @enddate as date

select @startdate = 
(case when DATEPART(WEEKDAY, @currentdate) = 1 then DATEADD(DAY,-2,@currentdate) 
when DATEPART(WEEKDAY, @currentdate) = 2 then DATEADD(DAY,-3,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 3 then DATEADD(DAY,-4,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 4 then DATEADD(DAY,-5,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 5 then DATEADD(DAY,-6,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 6 then DATEADD(DAY,0,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 7 then DATEADD(DAY,-1,@currentdate)
end )

select @enddate = 
(case when DATEPART(WEEKDAY, @currentdate) = 1 then DATEADD(DAY,4,@currentdate) 
when DATEPART(WEEKDAY, @currentdate) = 2 then DATEADD(DAY,3,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 3 then DATEADD(DAY,2,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 4 then DATEADD(DAY,1,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 5 then DATEADD(DAY,0,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 6 then DATEADD(DAY,6,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 7 then DATEADD(DAY,5,@currentdate)
end )


select top 5 vw.* , p1.PlayerPhoto from (
		SELECT ROW_NUMBER() OVER(order by isnull(cast(sum(ps.assists)as numeric),0) desc) AS Row,    
		p.LastName +', '+p.FirstName thisname, playerid thisid, 
		s.SeasonName, d.DiorganwshName, o.OmilosName, 
		k.KathgoriaName, k.Id KathgoriaId,
		t.teamname, t.id teamId,
		isnull(cast(sum(ps.assists)as numeric),0) totalassists
		from dbo.PlayersStatisticsTable ps
		inner join dbo.PlayersTable p on ps.Playerid = p.id 
		inner join dbo.GamesTable g on ps.Gameid = g.id
		inner join dbo.SeasonTable s on s.id = g.Seasonid
		inner join dbo.DiorganwshTable d on d.Id = g.Diorganwshid
		inner join dbo.OmilosTable o on o.Id = g.Omilosid
		inner join dbo.KathgoriesTable k on k.id = g.Kathgoriaid
		inner join dbo.TeamsStatisticsTable ts on ts.id = ps.teamstatisticsid and ts.Gameid = g.Id
		inner join dbo.TeamsTable t on t.id = ts.Teamid
		where 1=1 
				and (k.id = @kid or @kid=0)
		and cast(g.gamedate as date) between @startdate and @enddate
		group by p.LastName +', '+ p.FirstName, ps.playerid, 
		s.SeasonName, d.DiorganwshName, o.OmilosName, k.KathgoriaName, k.Id, t.teamname, t.id) as vw
		inner join dbo.playerstable p1 on vw.thisid = p1.id
	order by vw.totalassists desc
	
end


USE [atlas]
GO
/****** Object:  StoredProcedure [dbo].[GetWeeklyReportStat3All]    Script Date: 7/7/2017 2:35:21 πμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetWeeklyReportStat3All]
	@kid int
AS
BEGIN

declare @currentdate as date = cast('01/06/2017' as date)

declare @startdate as date, @enddate as date

select @startdate = 
(case when DATEPART(WEEKDAY, @currentdate) = 1 then DATEADD(DAY,-2,@currentdate) 
when DATEPART(WEEKDAY, @currentdate) = 2 then DATEADD(DAY,-3,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 3 then DATEADD(DAY,-4,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 4 then DATEADD(DAY,-5,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 5 then DATEADD(DAY,-6,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 6 then DATEADD(DAY,0,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 7 then DATEADD(DAY,-1,@currentdate)
end )

select @enddate = 
(case when DATEPART(WEEKDAY, @currentdate) = 1 then DATEADD(DAY,4,@currentdate) 
when DATEPART(WEEKDAY, @currentdate) = 2 then DATEADD(DAY,3,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 3 then DATEADD(DAY,2,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 4 then DATEADD(DAY,1,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 5 then DATEADD(DAY,0,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 6 then DATEADD(DAY,6,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 7 then DATEADD(DAY,5,@currentdate)
end )

select top 5 vw.* , p1.PlayerPhoto from (
		SELECT ROW_NUMBER() OVER(order by isnull(cast(sum(ps.rebounds)as numeric),0) desc) AS Row, 
		p.LastName +', '+p.FirstName thisname, playerid thisid, 
		s.SeasonName, d.DiorganwshName, o.OmilosName, 
		k.KathgoriaName, k.Id KathgoriaId,
		t.teamname, t.id teamId,
		isnull(cast(sum(ps.rebounds)as numeric),0) totalrebounds
		from dbo.PlayersStatisticsTable ps
		inner join dbo.PlayersTable p on ps.Playerid = p.id 
		inner join dbo.GamesTable g on ps.Gameid = g.id
		inner join dbo.SeasonTable s on s.id = g.Seasonid
		inner join dbo.DiorganwshTable d on d.Id = g.Diorganwshid
		inner join dbo.OmilosTable o on o.Id = g.Omilosid
		inner join dbo.KathgoriesTable k on k.id = g.Kathgoriaid
		inner join dbo.TeamsStatisticsTable ts on ts.id = ps.teamstatisticsid and ts.Gameid = g.Id
		inner join dbo.TeamsTable t on t.id = ts.Teamid
		where 1=1 
				and (k.id = @kid or @kid=0)
		and cast(g.gamedate as date) between @startdate and @enddate
		group by p.LastName +', '+ p.FirstName, ps.playerid, 
		s.SeasonName, d.DiorganwshName, o.OmilosName, k.KathgoriaName, k.Id, t.teamname, t.id) as vw
		inner join dbo.playerstable p1 on vw.thisid = p1.id
	order by vw.totalrebounds desc
	
end

USE [atlas]
GO
/****** Object:  StoredProcedure [dbo].[GetWeeklyReportStat4All]    Script Date: 7/7/2017 2:35:23 πμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetWeeklyReportStat4All]
	@kid int
AS
BEGIN


declare @currentdate as date = cast('01/06/2017' as date)

declare @startdate as date, @enddate as date

select @startdate = 
(case when DATEPART(WEEKDAY, @currentdate) = 1 then DATEADD(DAY,-2,@currentdate) 
when DATEPART(WEEKDAY, @currentdate) = 2 then DATEADD(DAY,-3,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 3 then DATEADD(DAY,-4,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 4 then DATEADD(DAY,-5,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 5 then DATEADD(DAY,-6,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 6 then DATEADD(DAY,0,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 7 then DATEADD(DAY,-1,@currentdate)
end )

select @enddate = 
(case when DATEPART(WEEKDAY, @currentdate) = 1 then DATEADD(DAY,4,@currentdate) 
when DATEPART(WEEKDAY, @currentdate) = 2 then DATEADD(DAY,3,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 3 then DATEADD(DAY,2,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 4 then DATEADD(DAY,1,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 5 then DATEADD(DAY,0,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 6 then DATEADD(DAY,6,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 7 then DATEADD(DAY,5,@currentdate)
end )



select top 5 vw.* , p1.PlayerPhoto from (
		SELECT ROW_NUMBER() OVER(order by isnull(cast(sum(ps.ptstotal)as numeric),0) desc) AS Row,    
		p.LastName +', '+p.FirstName thisname, playerid thisid, 
		s.SeasonName, d.DiorganwshName, o.OmilosName, 
		k.KathgoriaName, k.Id KathgoriaId,
		t.teamname, t.id teamId,
		isnull(cast(sum(ps.steals)as numeric),0) totalsteals
		from dbo.PlayersStatisticsTable ps
		inner join dbo.PlayersTable p on ps.Playerid = p.id 
		inner join dbo.GamesTable g on ps.Gameid = g.id
		inner join dbo.SeasonTable s on s.id = g.Seasonid
		inner join dbo.DiorganwshTable d on d.Id = g.Diorganwshid
		inner join dbo.OmilosTable o on o.Id = g.Omilosid
		inner join dbo.KathgoriesTable k on k.id = g.Kathgoriaid
		inner join dbo.TeamsStatisticsTable ts on ts.id = ps.teamstatisticsid and ts.Gameid = g.Id
		inner join dbo.TeamsTable t on t.id = ts.Teamid
		where 1=1 
				and (k.id = @kid or @kid=0)
		and cast(g.gamedate as date) between @startdate and @enddate
		group by p.LastName +', '+ p.FirstName, ps.playerid, 
		s.SeasonName, d.DiorganwshName, o.OmilosName, k.KathgoriaName, k.Id, t.teamname, t.id) as vw
		inner join dbo.playerstable p1 on vw.thisid = p1.id
	order by vw.totalsteals desc
	
end


---------------------------


USE [atlas]
GO
/****** Object:  StoredProcedure [dbo].[GetWeeklyReportStat5All]    Script Date: 7/7/2017 2:35:25 πμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetWeeklyReportStat5All]
	@kid int
AS
BEGIN


declare @currentdate as date = cast('01/06/2017' as date)

declare @startdate as date, @enddate as date

select @startdate = 
(case when DATEPART(WEEKDAY, @currentdate) = 1 then DATEADD(DAY,-2,@currentdate) 
when DATEPART(WEEKDAY, @currentdate) = 2 then DATEADD(DAY,-3,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 3 then DATEADD(DAY,-4,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 4 then DATEADD(DAY,-5,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 5 then DATEADD(DAY,-6,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 6 then DATEADD(DAY,0,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 7 then DATEADD(DAY,-1,@currentdate)
end )

select @enddate = 
(case when DATEPART(WEEKDAY, @currentdate) = 1 then DATEADD(DAY,4,@currentdate) 
when DATEPART(WEEKDAY, @currentdate) = 2 then DATEADD(DAY,3,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 3 then DATEADD(DAY,2,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 4 then DATEADD(DAY,1,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 5 then DATEADD(DAY,0,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 6 then DATEADD(DAY,6,@currentdate)
when DATEPART(WEEKDAY, @currentdate) = 7 then DATEADD(DAY,5,@currentdate)
end )



select top 5 vw.* , p1.PlayerPhoto from (
		SELECT ROW_NUMBER() OVER(order by isnull(cast(sum(ps.ptstotal)as numeric),0) desc) AS Row,    
		p.LastName +', '+p.FirstName thisname, playerid thisid, 
		s.SeasonName, d.DiorganwshName, o.OmilosName, 
		k.KathgoriaName, k.Id KathgoriaId,
		t.teamname, t.id teamId,
		isnull(cast(sum(ps.blocks)as numeric),0) totalblocks
		from dbo.PlayersStatisticsTable ps
		inner join dbo.PlayersTable p on ps.Playerid = p.id 
		inner join dbo.GamesTable g on ps.Gameid = g.id
		inner join dbo.SeasonTable s on s.id = g.Seasonid
		inner join dbo.DiorganwshTable d on d.Id = g.Diorganwshid
		inner join dbo.OmilosTable o on o.Id = g.Omilosid
		inner join dbo.KathgoriesTable k on k.id = g.Kathgoriaid
		inner join dbo.TeamsStatisticsTable ts on ts.id = ps.teamstatisticsid and ts.Gameid = g.Id
		inner join dbo.TeamsTable t on t.id = ts.Teamid
		where 1=1 
				and (k.id = @kid or @kid=0)
		and cast(g.gamedate as date) between @startdate and @enddate
		group by p.LastName +', '+ p.FirstName, ps.playerid, 
		s.SeasonName, d.DiorganwshName, o.OmilosName, k.KathgoriaName, k.Id, t.teamname, t.id) as vw
		inner join dbo.playerstable p1 on vw.thisid = p1.id
	
	order by vw.totalblocks desc
	
end