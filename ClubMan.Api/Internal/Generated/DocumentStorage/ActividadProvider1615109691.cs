// <auto-generated/>
#pragma warning disable
using ClubMan.Shared.Model;
using Marten.Internal;
using Marten.Internal.Storage;
using Marten.Schema;
using Marten.Schema.Arguments;
using Npgsql;
using System;
using System.Collections.Generic;
using Weasel.Core;
using Weasel.Postgresql;

namespace Marten.Generated.DocumentStorage
{
    // START: UpsertActividadOperation1615109691
    public class UpsertActividadOperation1615109691 : Marten.Internal.Operations.StorageOperation<ClubMan.Shared.Model.Actividad, System.Guid>
    {
        private readonly ClubMan.Shared.Model.Actividad _document;
        private readonly System.Guid _id;
        private readonly System.Collections.Generic.Dictionary<System.Guid, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;
        private readonly string _tenantId;

        public UpsertActividadOperation1615109691(ClubMan.Shared.Model.Actividad document, System.Guid id, System.Collections.Generic.Dictionary<System.Guid, System.Guid> versions, Marten.Schema.DocumentMapping mapping, string tenantId) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
            _tenantId = tenantId;
        }


        public const string COMMAND_TEXT = "select public.mt_upsert_actividad(?, ?, ?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Uuid;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, ClubMan.Shared.Model.Actividad document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[0].Value = document.InstalacionId;
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[1].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[2].Value = _document.GetType().FullName;
            parameters[3].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[3].Value = document.Id;
            setVersionParameter(parameters[4]);
            parameters[5].Value = _tenantId;
            parameters[5].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
        }


        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
        }


        public override System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            // Nothing
            return System.Threading.Tasks.Task.CompletedTask;
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Upsert;
        }

    }

    // END: UpsertActividadOperation1615109691
    
    
    // START: InsertActividadOperation1615109691
    public class InsertActividadOperation1615109691 : Marten.Internal.Operations.StorageOperation<ClubMan.Shared.Model.Actividad, System.Guid>
    {
        private readonly ClubMan.Shared.Model.Actividad _document;
        private readonly System.Guid _id;
        private readonly System.Collections.Generic.Dictionary<System.Guid, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;
        private readonly string _tenantId;

        public InsertActividadOperation1615109691(ClubMan.Shared.Model.Actividad document, System.Guid id, System.Collections.Generic.Dictionary<System.Guid, System.Guid> versions, Marten.Schema.DocumentMapping mapping, string tenantId) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
            _tenantId = tenantId;
        }


        public const string COMMAND_TEXT = "select public.mt_insert_actividad(?, ?, ?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Uuid;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, ClubMan.Shared.Model.Actividad document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[0].Value = document.InstalacionId;
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[1].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[2].Value = _document.GetType().FullName;
            parameters[3].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[3].Value = document.Id;
            setVersionParameter(parameters[4]);
            parameters[5].Value = _tenantId;
            parameters[5].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
        }


        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
        }


        public override System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            // Nothing
            return System.Threading.Tasks.Task.CompletedTask;
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Insert;
        }

    }

    // END: InsertActividadOperation1615109691
    
    
    // START: UpdateActividadOperation1615109691
    public class UpdateActividadOperation1615109691 : Marten.Internal.Operations.StorageOperation<ClubMan.Shared.Model.Actividad, System.Guid>
    {
        private readonly ClubMan.Shared.Model.Actividad _document;
        private readonly System.Guid _id;
        private readonly System.Collections.Generic.Dictionary<System.Guid, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;
        private readonly string _tenantId;

        public UpdateActividadOperation1615109691(ClubMan.Shared.Model.Actividad document, System.Guid id, System.Collections.Generic.Dictionary<System.Guid, System.Guid> versions, Marten.Schema.DocumentMapping mapping, string tenantId) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
            _tenantId = tenantId;
        }


        public const string COMMAND_TEXT = "select public.mt_update_actividad(?, ?, ?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Uuid;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, ClubMan.Shared.Model.Actividad document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[0].Value = document.InstalacionId;
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[1].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[2].Value = _document.GetType().FullName;
            parameters[3].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[3].Value = document.Id;
            setVersionParameter(parameters[4]);
            parameters[5].Value = _tenantId;
            parameters[5].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
        }


        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
            postprocessUpdate(reader, exceptions);
        }


        public override async System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            await postprocessUpdateAsync(reader, exceptions, token);
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Update;
        }

    }

    // END: UpdateActividadOperation1615109691
    
    
    // START: QueryOnlyActividadSelector1615109691
    public class QueryOnlyActividadSelector1615109691 : Marten.Internal.CodeGeneration.DocumentSelectorWithOnlySerializer, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.Actividad>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public QueryOnlyActividadSelector1615109691(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.Actividad Resolve(System.Data.Common.DbDataReader reader)
        {

            ClubMan.Shared.Model.Actividad document;
            document = _serializer.FromJson<ClubMan.Shared.Model.Actividad>(reader, 0);
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.Actividad> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {

            ClubMan.Shared.Model.Actividad document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.Actividad>(reader, 0, token).ConfigureAwait(false);
            return document;
        }

    }

    // END: QueryOnlyActividadSelector1615109691
    
    
    // START: LightweightActividadSelector1615109691
    public class LightweightActividadSelector1615109691 : Marten.Internal.CodeGeneration.DocumentSelectorWithVersions<ClubMan.Shared.Model.Actividad, System.Guid>, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.Actividad>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public LightweightActividadSelector1615109691(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.Actividad Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<System.Guid>(0);

            ClubMan.Shared.Model.Actividad document;
            document = _serializer.FromJson<ClubMan.Shared.Model.Actividad>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.Actividad> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<System.Guid>(0, token);

            ClubMan.Shared.Model.Actividad document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.Actividad>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }

    }

    // END: LightweightActividadSelector1615109691
    
    
    // START: IdentityMapActividadSelector1615109691
    public class IdentityMapActividadSelector1615109691 : Marten.Internal.CodeGeneration.DocumentSelectorWithIdentityMap<ClubMan.Shared.Model.Actividad, System.Guid>, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.Actividad>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public IdentityMapActividadSelector1615109691(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.Actividad Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<System.Guid>(0);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.Actividad document;
            document = _serializer.FromJson<ClubMan.Shared.Model.Actividad>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.Actividad> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<System.Guid>(0, token);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.Actividad document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.Actividad>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }

    }

    // END: IdentityMapActividadSelector1615109691
    
    
    // START: DirtyTrackingActividadSelector1615109691
    public class DirtyTrackingActividadSelector1615109691 : Marten.Internal.CodeGeneration.DocumentSelectorWithDirtyChecking<ClubMan.Shared.Model.Actividad, System.Guid>, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.Actividad>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public DirtyTrackingActividadSelector1615109691(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.Actividad Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<System.Guid>(0);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.Actividad document;
            document = _serializer.FromJson<ClubMan.Shared.Model.Actividad>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.Actividad> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<System.Guid>(0, token);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.Actividad document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.Actividad>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }

    }

    // END: DirtyTrackingActividadSelector1615109691
    
    
    // START: QueryOnlyActividadDocumentStorage1615109691
    public class QueryOnlyActividadDocumentStorage1615109691 : Marten.Internal.Storage.QueryOnlyDocumentStorage<ClubMan.Shared.Model.Actividad, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public QueryOnlyActividadDocumentStorage1615109691(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(ClubMan.Shared.Model.Actividad document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.Actividad document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateActividadOperation1615109691
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Actividad, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.Actividad document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertActividadOperation1615109691
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Actividad, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.Actividad document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertActividadOperation1615109691
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Actividad, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.Actividad document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(ClubMan.Shared.Model.Actividad document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.QueryOnlyActividadSelector1615109691(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(System.Guid id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id).With(TenantIdArgument.ArgName, tenant);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Guid[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids).With(TenantIdArgument.ArgName, tenant);
        }

    }

    // END: QueryOnlyActividadDocumentStorage1615109691
    
    
    // START: LightweightActividadDocumentStorage1615109691
    public class LightweightActividadDocumentStorage1615109691 : Marten.Internal.Storage.LightweightDocumentStorage<ClubMan.Shared.Model.Actividad, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public LightweightActividadDocumentStorage1615109691(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(ClubMan.Shared.Model.Actividad document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.Actividad document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateActividadOperation1615109691
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Actividad, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.Actividad document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertActividadOperation1615109691
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Actividad, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.Actividad document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertActividadOperation1615109691
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Actividad, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.Actividad document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(ClubMan.Shared.Model.Actividad document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.LightweightActividadSelector1615109691(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(System.Guid id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id).With(TenantIdArgument.ArgName, tenant);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Guid[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids).With(TenantIdArgument.ArgName, tenant);
        }

    }

    // END: LightweightActividadDocumentStorage1615109691
    
    
    // START: IdentityMapActividadDocumentStorage1615109691
    public class IdentityMapActividadDocumentStorage1615109691 : Marten.Internal.Storage.IdentityMapDocumentStorage<ClubMan.Shared.Model.Actividad, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public IdentityMapActividadDocumentStorage1615109691(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(ClubMan.Shared.Model.Actividad document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.Actividad document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateActividadOperation1615109691
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Actividad, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.Actividad document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertActividadOperation1615109691
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Actividad, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.Actividad document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertActividadOperation1615109691
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Actividad, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.Actividad document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(ClubMan.Shared.Model.Actividad document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.IdentityMapActividadSelector1615109691(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(System.Guid id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id).With(TenantIdArgument.ArgName, tenant);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Guid[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids).With(TenantIdArgument.ArgName, tenant);
        }

    }

    // END: IdentityMapActividadDocumentStorage1615109691
    
    
    // START: DirtyTrackingActividadDocumentStorage1615109691
    public class DirtyTrackingActividadDocumentStorage1615109691 : Marten.Internal.Storage.DirtyCheckedDocumentStorage<ClubMan.Shared.Model.Actividad, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public DirtyTrackingActividadDocumentStorage1615109691(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(ClubMan.Shared.Model.Actividad document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.Actividad document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateActividadOperation1615109691
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Actividad, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.Actividad document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertActividadOperation1615109691
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Actividad, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.Actividad document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertActividadOperation1615109691
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Actividad, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.Actividad document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(ClubMan.Shared.Model.Actividad document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.DirtyTrackingActividadSelector1615109691(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(System.Guid id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id).With(TenantIdArgument.ArgName, tenant);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Guid[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids).With(TenantIdArgument.ArgName, tenant);
        }

    }

    // END: DirtyTrackingActividadDocumentStorage1615109691
    
    
    // START: ActividadBulkLoader1615109691
    public class ActividadBulkLoader1615109691 : Marten.Internal.CodeGeneration.BulkLoader<ClubMan.Shared.Model.Actividad, System.Guid>
    {
        private readonly Marten.Internal.Storage.IDocumentStorage<ClubMan.Shared.Model.Actividad, System.Guid> _storage;

        public ActividadBulkLoader1615109691(Marten.Internal.Storage.IDocumentStorage<ClubMan.Shared.Model.Actividad, System.Guid> storage) : base(storage)
        {
            _storage = storage;
        }


        public const string MAIN_LOADER_SQL = "COPY public.mt_doc_actividad(\"instalacion_id\", \"mt_dotnet_type\", \"id\", \"mt_version\", \"tenant_id\", \"data\") FROM STDIN BINARY";

        public const string TEMP_LOADER_SQL = "COPY mt_doc_actividad_temp(\"instalacion_id\", \"mt_dotnet_type\", \"id\", \"mt_version\", \"tenant_id\", \"data\") FROM STDIN BINARY";

        public const string COPY_NEW_DOCUMENTS_SQL = "insert into public.mt_doc_actividad (\"id\", \"tenant_id\", \"data\", \"mt_version\", \"mt_dotnet_type\", \"instalacion_id\", mt_last_modified) (select mt_doc_actividad_temp.\"id\", mt_doc_actividad_temp.\"tenant_id\", mt_doc_actividad_temp.\"data\", mt_doc_actividad_temp.\"mt_version\", mt_doc_actividad_temp.\"mt_dotnet_type\", mt_doc_actividad_temp.\"instalacion_id\", transaction_timestamp() from mt_doc_actividad_temp left join public.mt_doc_actividad on mt_doc_actividad_temp.id = public.mt_doc_actividad.id where public.mt_doc_actividad.id is null)";

        public const string OVERWRITE_SQL = "update public.mt_doc_actividad target SET tenant_id = source.tenant_id, data = source.data, mt_version = source.mt_version, mt_dotnet_type = source.mt_dotnet_type, instalacion_id = source.instalacion_id, mt_last_modified = transaction_timestamp() FROM mt_doc_actividad_temp source WHERE source.id = target.id";

        public const string CREATE_TEMP_TABLE_FOR_COPYING_SQL = "create temporary table mt_doc_actividad_temp as select * from public.mt_doc_actividad limit 0";


        public override void LoadRow(Npgsql.NpgsqlBinaryImporter writer, ClubMan.Shared.Model.Actividad document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer)
        {
            writer.Write(document.InstalacionId, NpgsqlTypes.NpgsqlDbType.Uuid);
            writer.Write(document.GetType().FullName, NpgsqlTypes.NpgsqlDbType.Varchar);
            writer.Write(document.Id, NpgsqlTypes.NpgsqlDbType.Uuid);
            writer.Write(Marten.Schema.Identity.CombGuidIdGeneration.NewGuid(), NpgsqlTypes.NpgsqlDbType.Uuid);
            writer.Write(tenant.TenantId, NpgsqlTypes.NpgsqlDbType.Varchar);
            writer.Write(serializer.ToJson(document), NpgsqlTypes.NpgsqlDbType.Jsonb);
        }


        public override async System.Threading.Tasks.Task LoadRowAsync(Npgsql.NpgsqlBinaryImporter writer, ClubMan.Shared.Model.Actividad document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer, System.Threading.CancellationToken cancellation)
        {
            await writer.WriteAsync(document.InstalacionId, NpgsqlTypes.NpgsqlDbType.Uuid, cancellation);
            await writer.WriteAsync(document.GetType().FullName, NpgsqlTypes.NpgsqlDbType.Varchar, cancellation);
            await writer.WriteAsync(document.Id, NpgsqlTypes.NpgsqlDbType.Uuid, cancellation);
            await writer.WriteAsync(Marten.Schema.Identity.CombGuidIdGeneration.NewGuid(), NpgsqlTypes.NpgsqlDbType.Uuid, cancellation);
            await writer.WriteAsync(tenant.TenantId, NpgsqlTypes.NpgsqlDbType.Varchar, cancellation);
            await writer.WriteAsync(serializer.ToJson(document), NpgsqlTypes.NpgsqlDbType.Jsonb, cancellation);
        }


        public override string MainLoaderSql()
        {
            return MAIN_LOADER_SQL;
        }


        public override string TempLoaderSql()
        {
            return TEMP_LOADER_SQL;
        }


        public override string CreateTempTableForCopying()
        {
            return CREATE_TEMP_TABLE_FOR_COPYING_SQL;
        }


        public override string CopyNewDocumentsFromTempTable()
        {
            return COPY_NEW_DOCUMENTS_SQL;
        }


        public override string OverwriteDuplicatesFromTempTable()
        {
            return OVERWRITE_SQL;
        }

    }

    // END: ActividadBulkLoader1615109691
    
    
    // START: ActividadProvider1615109691
    public class ActividadProvider1615109691 : Marten.Internal.Storage.DocumentProvider<ClubMan.Shared.Model.Actividad>
    {
        private readonly Marten.Schema.DocumentMapping _mapping;

        public ActividadProvider1615109691(Marten.Schema.DocumentMapping mapping) : base(new ActividadBulkLoader1615109691(new QueryOnlyActividadDocumentStorage1615109691(mapping)), new QueryOnlyActividadDocumentStorage1615109691(mapping), new LightweightActividadDocumentStorage1615109691(mapping), new IdentityMapActividadDocumentStorage1615109691(mapping), new DirtyTrackingActividadDocumentStorage1615109691(mapping))
        {
            _mapping = mapping;
        }


    }

    // END: ActividadProvider1615109691
    
    
}

