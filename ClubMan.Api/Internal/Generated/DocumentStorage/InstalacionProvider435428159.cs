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
    // START: UpsertInstalacionOperation435428159
    public class UpsertInstalacionOperation435428159 : Marten.Internal.Operations.StorageOperation<ClubMan.Shared.Model.Instalacion, System.Guid>
    {
        private readonly ClubMan.Shared.Model.Instalacion _document;
        private readonly System.Guid _id;
        private readonly System.Collections.Generic.Dictionary<System.Guid, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;
        private readonly string _tenantId;

        public UpsertInstalacionOperation435428159(ClubMan.Shared.Model.Instalacion document, System.Guid id, System.Collections.Generic.Dictionary<System.Guid, System.Guid> versions, Marten.Schema.DocumentMapping mapping, string tenantId) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
            _tenantId = tenantId;
        }


        public const string COMMAND_TEXT = "select public.mt_upsert_instalacion(?, ?, ?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Uuid;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, ClubMan.Shared.Model.Instalacion document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[0].Value = document.LocalidadId;
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

    // END: UpsertInstalacionOperation435428159
    
    
    // START: InsertInstalacionOperation435428159
    public class InsertInstalacionOperation435428159 : Marten.Internal.Operations.StorageOperation<ClubMan.Shared.Model.Instalacion, System.Guid>
    {
        private readonly ClubMan.Shared.Model.Instalacion _document;
        private readonly System.Guid _id;
        private readonly System.Collections.Generic.Dictionary<System.Guid, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;
        private readonly string _tenantId;

        public InsertInstalacionOperation435428159(ClubMan.Shared.Model.Instalacion document, System.Guid id, System.Collections.Generic.Dictionary<System.Guid, System.Guid> versions, Marten.Schema.DocumentMapping mapping, string tenantId) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
            _tenantId = tenantId;
        }


        public const string COMMAND_TEXT = "select public.mt_insert_instalacion(?, ?, ?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Uuid;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, ClubMan.Shared.Model.Instalacion document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[0].Value = document.LocalidadId;
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

    // END: InsertInstalacionOperation435428159
    
    
    // START: UpdateInstalacionOperation435428159
    public class UpdateInstalacionOperation435428159 : Marten.Internal.Operations.StorageOperation<ClubMan.Shared.Model.Instalacion, System.Guid>
    {
        private readonly ClubMan.Shared.Model.Instalacion _document;
        private readonly System.Guid _id;
        private readonly System.Collections.Generic.Dictionary<System.Guid, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;
        private readonly string _tenantId;

        public UpdateInstalacionOperation435428159(ClubMan.Shared.Model.Instalacion document, System.Guid id, System.Collections.Generic.Dictionary<System.Guid, System.Guid> versions, Marten.Schema.DocumentMapping mapping, string tenantId) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
            _tenantId = tenantId;
        }


        public const string COMMAND_TEXT = "select public.mt_update_instalacion(?, ?, ?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Uuid;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, ClubMan.Shared.Model.Instalacion document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Uuid;
            parameters[0].Value = document.LocalidadId;
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

    // END: UpdateInstalacionOperation435428159
    
    
    // START: QueryOnlyInstalacionSelector435428159
    public class QueryOnlyInstalacionSelector435428159 : Marten.Internal.CodeGeneration.DocumentSelectorWithOnlySerializer, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.Instalacion>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public QueryOnlyInstalacionSelector435428159(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.Instalacion Resolve(System.Data.Common.DbDataReader reader)
        {

            ClubMan.Shared.Model.Instalacion document;
            document = _serializer.FromJson<ClubMan.Shared.Model.Instalacion>(reader, 0);
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.Instalacion> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {

            ClubMan.Shared.Model.Instalacion document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.Instalacion>(reader, 0, token).ConfigureAwait(false);
            return document;
        }

    }

    // END: QueryOnlyInstalacionSelector435428159
    
    
    // START: LightweightInstalacionSelector435428159
    public class LightweightInstalacionSelector435428159 : Marten.Internal.CodeGeneration.DocumentSelectorWithVersions<ClubMan.Shared.Model.Instalacion, System.Guid>, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.Instalacion>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public LightweightInstalacionSelector435428159(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.Instalacion Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<System.Guid>(0);

            ClubMan.Shared.Model.Instalacion document;
            document = _serializer.FromJson<ClubMan.Shared.Model.Instalacion>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.Instalacion> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<System.Guid>(0, token);

            ClubMan.Shared.Model.Instalacion document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.Instalacion>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }

    }

    // END: LightweightInstalacionSelector435428159
    
    
    // START: IdentityMapInstalacionSelector435428159
    public class IdentityMapInstalacionSelector435428159 : Marten.Internal.CodeGeneration.DocumentSelectorWithIdentityMap<ClubMan.Shared.Model.Instalacion, System.Guid>, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.Instalacion>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public IdentityMapInstalacionSelector435428159(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.Instalacion Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<System.Guid>(0);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.Instalacion document;
            document = _serializer.FromJson<ClubMan.Shared.Model.Instalacion>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.Instalacion> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<System.Guid>(0, token);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.Instalacion document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.Instalacion>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }

    }

    // END: IdentityMapInstalacionSelector435428159
    
    
    // START: DirtyTrackingInstalacionSelector435428159
    public class DirtyTrackingInstalacionSelector435428159 : Marten.Internal.CodeGeneration.DocumentSelectorWithDirtyChecking<ClubMan.Shared.Model.Instalacion, System.Guid>, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.Instalacion>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public DirtyTrackingInstalacionSelector435428159(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.Instalacion Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<System.Guid>(0);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.Instalacion document;
            document = _serializer.FromJson<ClubMan.Shared.Model.Instalacion>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.Instalacion> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<System.Guid>(0, token);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.Instalacion document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.Instalacion>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }

    }

    // END: DirtyTrackingInstalacionSelector435428159
    
    
    // START: QueryOnlyInstalacionDocumentStorage435428159
    public class QueryOnlyInstalacionDocumentStorage435428159 : Marten.Internal.Storage.QueryOnlyDocumentStorage<ClubMan.Shared.Model.Instalacion, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public QueryOnlyInstalacionDocumentStorage435428159(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(ClubMan.Shared.Model.Instalacion document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.Instalacion document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateInstalacionOperation435428159
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Instalacion, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.Instalacion document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertInstalacionOperation435428159
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Instalacion, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.Instalacion document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertInstalacionOperation435428159
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Instalacion, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.Instalacion document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(ClubMan.Shared.Model.Instalacion document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.QueryOnlyInstalacionSelector435428159(session, _document);
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

    // END: QueryOnlyInstalacionDocumentStorage435428159
    
    
    // START: LightweightInstalacionDocumentStorage435428159
    public class LightweightInstalacionDocumentStorage435428159 : Marten.Internal.Storage.LightweightDocumentStorage<ClubMan.Shared.Model.Instalacion, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public LightweightInstalacionDocumentStorage435428159(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(ClubMan.Shared.Model.Instalacion document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.Instalacion document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateInstalacionOperation435428159
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Instalacion, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.Instalacion document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertInstalacionOperation435428159
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Instalacion, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.Instalacion document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertInstalacionOperation435428159
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Instalacion, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.Instalacion document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(ClubMan.Shared.Model.Instalacion document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.LightweightInstalacionSelector435428159(session, _document);
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

    // END: LightweightInstalacionDocumentStorage435428159
    
    
    // START: IdentityMapInstalacionDocumentStorage435428159
    public class IdentityMapInstalacionDocumentStorage435428159 : Marten.Internal.Storage.IdentityMapDocumentStorage<ClubMan.Shared.Model.Instalacion, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public IdentityMapInstalacionDocumentStorage435428159(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(ClubMan.Shared.Model.Instalacion document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.Instalacion document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateInstalacionOperation435428159
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Instalacion, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.Instalacion document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertInstalacionOperation435428159
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Instalacion, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.Instalacion document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertInstalacionOperation435428159
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Instalacion, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.Instalacion document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(ClubMan.Shared.Model.Instalacion document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.IdentityMapInstalacionSelector435428159(session, _document);
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

    // END: IdentityMapInstalacionDocumentStorage435428159
    
    
    // START: DirtyTrackingInstalacionDocumentStorage435428159
    public class DirtyTrackingInstalacionDocumentStorage435428159 : Marten.Internal.Storage.DirtyCheckedDocumentStorage<ClubMan.Shared.Model.Instalacion, System.Guid>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public DirtyTrackingInstalacionDocumentStorage435428159(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override System.Guid AssignIdentity(ClubMan.Shared.Model.Instalacion document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id == Guid.Empty) _setter(document, Marten.Schema.Identity.CombGuidIdGeneration.NewGuid());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.Instalacion document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateInstalacionOperation435428159
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Instalacion, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.Instalacion document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertInstalacionOperation435428159
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Instalacion, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.Instalacion document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertInstalacionOperation435428159
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Instalacion, System.Guid>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.Instalacion document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override System.Guid Identity(ClubMan.Shared.Model.Instalacion document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.DirtyTrackingInstalacionSelector435428159(session, _document);
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

    // END: DirtyTrackingInstalacionDocumentStorage435428159
    
    
    // START: InstalacionBulkLoader435428159
    public class InstalacionBulkLoader435428159 : Marten.Internal.CodeGeneration.BulkLoader<ClubMan.Shared.Model.Instalacion, System.Guid>
    {
        private readonly Marten.Internal.Storage.IDocumentStorage<ClubMan.Shared.Model.Instalacion, System.Guid> _storage;

        public InstalacionBulkLoader435428159(Marten.Internal.Storage.IDocumentStorage<ClubMan.Shared.Model.Instalacion, System.Guid> storage) : base(storage)
        {
            _storage = storage;
        }


        public const string MAIN_LOADER_SQL = "COPY public.mt_doc_instalacion(\"localidad_id\", \"mt_dotnet_type\", \"id\", \"mt_version\", \"tenant_id\", \"data\") FROM STDIN BINARY";

        public const string TEMP_LOADER_SQL = "COPY mt_doc_instalacion_temp(\"localidad_id\", \"mt_dotnet_type\", \"id\", \"mt_version\", \"tenant_id\", \"data\") FROM STDIN BINARY";

        public const string COPY_NEW_DOCUMENTS_SQL = "insert into public.mt_doc_instalacion (\"id\", \"tenant_id\", \"data\", \"mt_version\", \"mt_dotnet_type\", \"localidad_id\", mt_last_modified) (select mt_doc_instalacion_temp.\"id\", mt_doc_instalacion_temp.\"tenant_id\", mt_doc_instalacion_temp.\"data\", mt_doc_instalacion_temp.\"mt_version\", mt_doc_instalacion_temp.\"mt_dotnet_type\", mt_doc_instalacion_temp.\"localidad_id\", transaction_timestamp() from mt_doc_instalacion_temp left join public.mt_doc_instalacion on mt_doc_instalacion_temp.id = public.mt_doc_instalacion.id where public.mt_doc_instalacion.id is null)";

        public const string OVERWRITE_SQL = "update public.mt_doc_instalacion target SET tenant_id = source.tenant_id, data = source.data, mt_version = source.mt_version, mt_dotnet_type = source.mt_dotnet_type, localidad_id = source.localidad_id, mt_last_modified = transaction_timestamp() FROM mt_doc_instalacion_temp source WHERE source.id = target.id";

        public const string CREATE_TEMP_TABLE_FOR_COPYING_SQL = "create temporary table mt_doc_instalacion_temp as select * from public.mt_doc_instalacion limit 0";


        public override void LoadRow(Npgsql.NpgsqlBinaryImporter writer, ClubMan.Shared.Model.Instalacion document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer)
        {
            writer.Write(document.LocalidadId, NpgsqlTypes.NpgsqlDbType.Uuid);
            writer.Write(document.GetType().FullName, NpgsqlTypes.NpgsqlDbType.Varchar);
            writer.Write(document.Id, NpgsqlTypes.NpgsqlDbType.Uuid);
            writer.Write(Marten.Schema.Identity.CombGuidIdGeneration.NewGuid(), NpgsqlTypes.NpgsqlDbType.Uuid);
            writer.Write(tenant.TenantId, NpgsqlTypes.NpgsqlDbType.Varchar);
            writer.Write(serializer.ToJson(document), NpgsqlTypes.NpgsqlDbType.Jsonb);
        }


        public override async System.Threading.Tasks.Task LoadRowAsync(Npgsql.NpgsqlBinaryImporter writer, ClubMan.Shared.Model.Instalacion document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer, System.Threading.CancellationToken cancellation)
        {
            await writer.WriteAsync(document.LocalidadId, NpgsqlTypes.NpgsqlDbType.Uuid, cancellation);
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

    // END: InstalacionBulkLoader435428159
    
    
    // START: InstalacionProvider435428159
    public class InstalacionProvider435428159 : Marten.Internal.Storage.DocumentProvider<ClubMan.Shared.Model.Instalacion>
    {
        private readonly Marten.Schema.DocumentMapping _mapping;

        public InstalacionProvider435428159(Marten.Schema.DocumentMapping mapping) : base(new InstalacionBulkLoader435428159(new QueryOnlyInstalacionDocumentStorage435428159(mapping)), new QueryOnlyInstalacionDocumentStorage435428159(mapping), new LightweightInstalacionDocumentStorage435428159(mapping), new IdentityMapInstalacionDocumentStorage435428159(mapping), new DirtyTrackingInstalacionDocumentStorage435428159(mapping))
        {
            _mapping = mapping;
        }


    }

    // END: InstalacionProvider435428159
    
    
}
