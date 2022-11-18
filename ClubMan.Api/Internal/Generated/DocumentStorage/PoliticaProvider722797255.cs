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
    // START: UpsertPoliticaOperation722797255
    public class UpsertPoliticaOperation722797255 : Marten.Internal.Operations.StorageOperation<ClubMan.Shared.Model.Politica, System.Guid>
    {
        private readonly ClubMan.Shared.Model.Politica _document;
        private readonly System.Guid _id;
        private readonly System.Collections.Generic.Dictionary<System.Guid, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;
        private readonly string _tenantId;

        public UpsertPoliticaOperation722797255(ClubMan.Shared.Model.Politica document, System.Guid id, System.Collections.Generic.Dictionary<System.Guid, System.Guid> versions, Marten.Schema.DocumentMapping mapping, string tenantId) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
            _tenantId = tenantId;
        }


        public const string COMMAND_TEXT = "select public.mt_upsert_politica(?, ?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Uuid;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, ClubMan.Shared.Model.Politica document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[2].Value = document.Id;
            setVersionParameter(parameters[3]);
            parameters[4].Value = _tenantId;
            parameters[4].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
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

    // END: UpsertPoliticaOperation722797255
    
    
    // START: InsertPoliticaOperation722797255
    public class InsertPoliticaOperation722797255 : Marten.Internal.Operations.StorageOperation<ClubMan.Shared.Model.Politica, System.Guid>
    {
        private readonly ClubMan.Shared.Model.Politica _document;
        private readonly System.Guid _id;
        private readonly System.Collections.Generic.Dictionary<System.Guid, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;
        private readonly string _tenantId;

        public InsertPoliticaOperation722797255(ClubMan.Shared.Model.Politica document, System.Guid id, System.Collections.Generic.Dictionary<System.Guid, System.Guid> versions, Marten.Schema.DocumentMapping mapping, string tenantId) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
            _tenantId = tenantId;
        }


        public const string COMMAND_TEXT = "select public.mt_insert_politica(?, ?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Uuid;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, ClubMan.Shared.Model.Politica document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[2].Value = document.Id;
            setVersionParameter(parameters[3]);
            parameters[4].Value = _tenantId;
            parameters[4].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
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

    // END: InsertPoliticaOperation722797255
    
    
    // START: UpdatePoliticaOperation722797255
    public class UpdatePoliticaOperation722797255 : Marten.Internal.Operations.StorageOperation<ClubMan.Shared.Model.Politica, System.Guid>
    {
        private readonly ClubMan.Shared.Model.Politica _document;
        private readonly System.Guid _id;
        private readonly System.Collections.Generic.Dictionary<System.Guid, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;
        private readonly string _tenantId;

        public UpdatePoliticaOperation722797255(ClubMan.Shared.Model.Politica document, System.Guid id, System.Collections.Generic.Dictionary<System.Guid, System.Guid> versions, Marten.Schema.DocumentMapping mapping, string tenantId) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
            _tenantId = tenantId;
        }


        public const string COMMAND_TEXT = "select public.mt_update_politica(?, ?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Uuid;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, ClubMan.Shared.Model.Politica document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[2].Value = document.Id;
            setVersionParameter(parameters[3]);
            parameters[4].Value = _tenantId;
            parameters[4].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
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

    // END: UpdatePoliticaOperation722797255
    
    
    // START: QueryOnlyPoliticaSelector722797255
    public class QueryOnlyPoliticaSelector722797255 : Marten.Internal.CodeGeneration.DocumentSelectorWithOnlySerializer, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.Politica>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public QueryOnlyPoliticaSelector722797255(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.Politica Resolve(System.Data.Common.DbDataReader reader)
        {

            ClubMan.Shared.Model.Politica document;
            document = _serializer.FromJson<ClubMan.Shared.Model.Politica>(reader, 0);
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.Politica> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {

            ClubMan.Shared.Model.Politica document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.Politica>(reader, 0, token).ConfigureAwait(false);
            return document;
        }

    }

    // END: QueryOnlyPoliticaSelector722797255
    
    
    // START: LightweightPoliticaSelector722797255
    public class LightweightPoliticaSelector722797255 : Marten.Internal.CodeGeneration.DocumentSelectorWithVersions<ClubMan.Shared.Model.Politica, System.Guid>, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.Politica>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public LightweightPoliticaSelector722797255(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.Politica Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<System.Guid>(0);

            ClubMan.Shared.Model.Politica document;
            document = _serializer.FromJson<ClubMan.Shared.Model.Politica>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.Politica> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<System.Guid>(0, token);

            ClubMan.Shared.Model.Politica document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.Politica>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }

    }

    // END: LightweightPoliticaSelector722797255
    
    
    // START: IdentityMapPoliticaSelector722797255
    public class IdentityMapPoliticaSelector722797255 : Marten.Internal.CodeGeneration.DocumentSelectorWithIdentityMap<ClubMan.Shared.Model.Politica, System.Guid>, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.Politica>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public IdentityMapPoliticaSelector722797255(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.Politica Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<System.Guid>(0);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.Politica document;
            document = _serializer.FromJson<ClubMan.Shared.Model.Politica>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.Politica> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<System.Guid>(0, token);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.Politica document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.Politica>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }

    }

    // END: IdentityMapPoliticaSelector722797255
    
    
    // START: DirtyTrackingPoliticaSelector722797255
    public class DirtyTrackingPoliticaSelector722797255 : Marten.Internal.CodeGeneration.DocumentSelectorWithDirtyChecking<ClubMan.Shared.Model.Politica, System.Guid>, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.Politica>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public DirtyTrackingPoliticaSelector722797255(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.Politica Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<System.Guid>(0);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.Politica document;
            document = _serializer.FromJson<ClubMan.Shared.Model.Politica>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.Politica> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<System.Guid>(0, token);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.Politica document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.Politica>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }

    }

    // END: DirtyTrackingPoliticaSelector722797255
    
    
    // START: QueryOnlyPoliticaDocumentStorage722797255
    public class QueryOnlyPoliticaDocumentStorage722797255 : Marten.Internal.Storage.QueryOnlyDocumentStorage<ClubMan.Shared.Model.Politica, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public QueryOnlyPoliticaDocumentStorage722797255(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(ClubMan.Shared.Model.Politica document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.Politica document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdatePoliticaOperation722797255
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Politica, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.Politica document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertPoliticaOperation722797255
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Politica, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.Politica document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertPoliticaOperation722797255
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Politica, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.Politica document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(ClubMan.Shared.Model.Politica document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.QueryOnlyPoliticaSelector722797255(session, _document);
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

    // END: QueryOnlyPoliticaDocumentStorage722797255
    
    
    // START: LightweightPoliticaDocumentStorage722797255
    public class LightweightPoliticaDocumentStorage722797255 : Marten.Internal.Storage.LightweightDocumentStorage<ClubMan.Shared.Model.Politica, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public LightweightPoliticaDocumentStorage722797255(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(ClubMan.Shared.Model.Politica document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.Politica document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdatePoliticaOperation722797255
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Politica, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.Politica document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertPoliticaOperation722797255
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Politica, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.Politica document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertPoliticaOperation722797255
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Politica, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.Politica document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(ClubMan.Shared.Model.Politica document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.LightweightPoliticaSelector722797255(session, _document);
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

    // END: LightweightPoliticaDocumentStorage722797255
    
    
    // START: IdentityMapPoliticaDocumentStorage722797255
    public class IdentityMapPoliticaDocumentStorage722797255 : Marten.Internal.Storage.IdentityMapDocumentStorage<ClubMan.Shared.Model.Politica, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public IdentityMapPoliticaDocumentStorage722797255(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(ClubMan.Shared.Model.Politica document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.Politica document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdatePoliticaOperation722797255
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Politica, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.Politica document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertPoliticaOperation722797255
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Politica, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.Politica document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertPoliticaOperation722797255
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Politica, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.Politica document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(ClubMan.Shared.Model.Politica document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.IdentityMapPoliticaSelector722797255(session, _document);
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

    // END: IdentityMapPoliticaDocumentStorage722797255
    
    
    // START: DirtyTrackingPoliticaDocumentStorage722797255
    public class DirtyTrackingPoliticaDocumentStorage722797255 : Marten.Internal.Storage.DirtyCheckedDocumentStorage<ClubMan.Shared.Model.Politica, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public DirtyTrackingPoliticaDocumentStorage722797255(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(ClubMan.Shared.Model.Politica document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.Politica document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdatePoliticaOperation722797255
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Politica, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.Politica document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertPoliticaOperation722797255
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Politica, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.Politica document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertPoliticaOperation722797255
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Politica, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.Politica document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(ClubMan.Shared.Model.Politica document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.DirtyTrackingPoliticaSelector722797255(session, _document);
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

    // END: DirtyTrackingPoliticaDocumentStorage722797255
    
    
    // START: PoliticaBulkLoader722797255
    public class PoliticaBulkLoader722797255 : Marten.Internal.CodeGeneration.BulkLoader<ClubMan.Shared.Model.Politica, System.Guid>
    {
        private readonly Marten.Internal.Storage.IDocumentStorage<ClubMan.Shared.Model.Politica, System.Guid> _storage;

        public PoliticaBulkLoader722797255(Marten.Internal.Storage.IDocumentStorage<ClubMan.Shared.Model.Politica, System.Guid> storage) : base(storage)
        {
            _storage = storage;
        }


        public const string MAIN_LOADER_SQL = "COPY public.mt_doc_politica(\"mt_dotnet_type\", \"id\", \"mt_version\", \"tenant_id\", \"data\") FROM STDIN BINARY";

        public const string TEMP_LOADER_SQL = "COPY mt_doc_politica_temp(\"mt_dotnet_type\", \"id\", \"mt_version\", \"tenant_id\", \"data\") FROM STDIN BINARY";

        public const string COPY_NEW_DOCUMENTS_SQL = "insert into public.mt_doc_politica (\"id\", \"tenant_id\", \"data\", \"mt_version\", \"mt_dotnet_type\", mt_last_modified) (select mt_doc_politica_temp.\"id\", mt_doc_politica_temp.\"tenant_id\", mt_doc_politica_temp.\"data\", mt_doc_politica_temp.\"mt_version\", mt_doc_politica_temp.\"mt_dotnet_type\", transaction_timestamp() from mt_doc_politica_temp left join public.mt_doc_politica on mt_doc_politica_temp.id = public.mt_doc_politica.id where public.mt_doc_politica.id is null)";

        public const string OVERWRITE_SQL = "update public.mt_doc_politica target SET tenant_id = source.tenant_id, data = source.data, mt_version = source.mt_version, mt_dotnet_type = source.mt_dotnet_type, mt_last_modified = transaction_timestamp() FROM mt_doc_politica_temp source WHERE source.id = target.id";

        public const string CREATE_TEMP_TABLE_FOR_COPYING_SQL = "create temporary table mt_doc_politica_temp as select * from public.mt_doc_politica limit 0";


        public override void LoadRow(Npgsql.NpgsqlBinaryImporter writer, ClubMan.Shared.Model.Politica document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer)
        {
            writer.Write(document.GetType().FullName, NpgsqlTypes.NpgsqlDbType.Varchar);
            writer.Write(document.Id, NpgsqlTypes.NpgsqlDbType.Uuid);
            writer.Write(Marten.Schema.Identity.CombGuidIdGeneration.NewGuid(), NpgsqlTypes.NpgsqlDbType.Uuid);
            writer.Write(tenant.TenantId, NpgsqlTypes.NpgsqlDbType.Varchar);
            writer.Write(serializer.ToJson(document), NpgsqlTypes.NpgsqlDbType.Jsonb);
        }


        public override async System.Threading.Tasks.Task LoadRowAsync(Npgsql.NpgsqlBinaryImporter writer, ClubMan.Shared.Model.Politica document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer, System.Threading.CancellationToken cancellation)
        {
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

    // END: PoliticaBulkLoader722797255
    
    
    // START: PoliticaProvider722797255
    public class PoliticaProvider722797255 : Marten.Internal.Storage.DocumentProvider<ClubMan.Shared.Model.Politica>
    {
        private readonly Marten.Schema.DocumentMapping _mapping;

        public PoliticaProvider722797255(Marten.Schema.DocumentMapping mapping) : base(new PoliticaBulkLoader722797255(new QueryOnlyPoliticaDocumentStorage722797255(mapping)), new QueryOnlyPoliticaDocumentStorage722797255(mapping), new LightweightPoliticaDocumentStorage722797255(mapping), new IdentityMapPoliticaDocumentStorage722797255(mapping), new DirtyTrackingPoliticaDocumentStorage722797255(mapping))
        {
            _mapping = mapping;
        }


    }

    // END: PoliticaProvider722797255
    
    
}
