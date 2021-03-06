create PROCEDURE [dbo].[GetReportStat1All]
	@season int, 
	@diorganwsh int,
	@agwnistiki int
AS
BEGIN

select top 10 vw.*, p1.PlayerPhoto from (
		select p.LastName +', '+p.FirstName thisname, playerid thisid, 
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
		where 1=1 
		and ((g.Agwnistiki = @agwnistiki) or (@agwnistiki = 0))
		and (d.id = @diorganwsh or @diorganwsh=0)
		and (s.id = @season or @season=0)
		group by p.LastName +', '+ p.FirstName, ps.playerid, 
		s.SeasonName, d.DiorganwshName, o.OmilosName, k.KathgoriaName, k.Id, t.teamname, t.id) as vw
		inner join dbo.playerstable p1 on vw.thisid = p1.id
	order by vw.totalpoints desc
	
end

-----------


create PROCEDURE [dbo].[GetReportStat2All]
	@season int, 
	@diorganwsh int,
	@agwnistiki int
AS
BEGIN

select top 10 vw.*, p1.PlayerPhoto from (
			select p.LastName +', '+p.FirstName thisname, playerid thisid, 
		s.SeasonName, d.DiorganwshName, o.OmilosName, 
		k.KathgoriaName, k.Id KathgoriaId,
		t.teamname, t.id teamId,
		isnull(cast(sum(ps.assists) as numeric),0)  totalassists
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
		and ((g.Agwnistiki = @agwnistiki) or (@agwnistiki = 0))
		and (d.id = @diorganwsh or @diorganwsh=0)
		and (s.id = @season or @season=0)
		group by p.LastName +', '+ p.FirstName, ps.playerid, 
		s.SeasonName, d.DiorganwshName, o.OmilosName, k.KathgoriaName, k.Id, t.teamname, t.id) as vw
		inner join dbo.playerstable p1 on vw.thisid = p1.id
	order by vw.totalassists desc
	
end


--------------
create PROCEDURE [dbo].[GetReportStat3All]
	@season int, 
	@diorganwsh int,
	@agwnistiki int
AS
BEGIN

select top 10 vw.*, p1.PlayerPhoto from (
		select p.LastName +', '+p.FirstName thisname, playerid thisid, 
		s.SeasonName, d.DiorganwshName, o.OmilosName, 
		k.KathgoriaName, k.Id KathgoriaId,
		t.teamname, t.id teamId,
		isnull(cast(sum(ps.rebounds) as numeric),0)  totalrebounds
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
		and ((g.Agwnistiki = @agwnistiki) or (@agwnistiki = 0))
		and (d.id = @diorganwsh or @diorganwsh=0)
		and (s.id = @season or @season=0)
		group by p.LastName +', '+ p.FirstName, ps.playerid, 
		s.SeasonName, d.DiorganwshName, o.OmilosName, k.KathgoriaName, k.Id, t.teamname, t.id) as vw
		inner join dbo.playerstable p1 on vw.thisid = p1.id	
	order by vw.totalrebounds desc
	
end

--------------

create PROCEDURE [dbo].[GetReportStat4All]
	@season int, 
	@diorganwsh int,
	@agwnistiki int
AS
BEGIN

select top 10 vw.*, p1.PlayerPhoto
 from (
		select p.LastName +', '+p.FirstName thisname, playerid thisid, 
		s.SeasonName, d.DiorganwshName, o.OmilosName, 
		k.KathgoriaName, k.Id KathgoriaId,
		t.teamname, t.id teamId,
		isnull(cast(sum(ps.steals) as numeric),0)  totalsteals
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
		and ((g.Agwnistiki = @agwnistiki) or (@agwnistiki = 0))
		and (d.id = @diorganwsh or @diorganwsh=0)
		and (s.id = @season or @season=0)
		group by p.LastName +', '+ p.FirstName, ps.playerid, 
		s.SeasonName, d.DiorganwshName, o.OmilosName, k.KathgoriaName, k.Id, t.teamname, t.id) as vw
		inner join dbo.playerstable p1 on vw.thisid = p1.id	
	order by vw.totalsteals desc
	
end

---------------


create PROCEDURE [dbo].[GetReportStat5blog]
	@season int, 
	@diorganwsh int,
	@agwnistiki int
AS
BEGIN

select top 10 vw.*, p1.PlayerPhoto
from (
		select p.LastName +', '+p.FirstName thisname, playerid thisid, 
		s.SeasonName, d.DiorganwshName, o.OmilosName, 
		k.KathgoriaName, k.Id KathgoriaId,
		t.teamname, t.id teamId,
		isnull(cast(sum(ps.blocks) as numeric),0) totalblocks
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
		and ((g.Agwnistiki = @agwnistiki) or (@agwnistiki = 0))
		and (d.id = @diorganwsh or @diorganwsh=0)
		and (s.id = @season or @season=0)
		group by p.LastName +', '+ p.FirstName, ps.playerid, 
		s.SeasonName, d.DiorganwshName, o.OmilosName, k.KathgoriaName, k.Id, t.teamname, t.id) as vw
		inner join dbo.playerstable p1 on vw.thisid = p1.id
	order by vw.totalblocks desc
	
end