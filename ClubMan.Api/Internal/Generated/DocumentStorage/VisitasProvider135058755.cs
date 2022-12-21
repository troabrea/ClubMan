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
    // START: UpsertVisitasOperation135058755
    public class UpsertVisitasOperation135058755 : Marten.Internal.Operations.StorageOperation<ClubMan.Shared.Model.Visitas, string>
    {
        private readonly ClubMan.Shared.Model.Visitas _document;
        private readonly string _id;
        private readonly System.Collections.Generic.Dictionary<string, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;
        private readonly string _tenantId;

        public UpsertVisitasOperation135058755(ClubMan.Shared.Model.Visitas document, string id, System.Collections.Generic.Dictionary<string, System.Guid> versions, Marten.Schema.DocumentMapping mapping, string tenantId) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
            _tenantId = tenantId;
        }


        public const string COMMAND_TEXT = "select public.mt_upsert_visitas(?, ?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Text;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, ClubMan.Shared.Model.Visitas document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Text;

            if (document.Id != null)
            {
                parameters[2].Value = document.Id;
            }

            else
            {
                parameters[2].Value = System.DBNull.Value;
            }

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

    // END: UpsertVisitasOperation135058755
    
    
    // START: InsertVisitasOperation135058755
    public class InsertVisitasOperation135058755 : Marten.Internal.Operations.StorageOperation<ClubMan.Shared.Model.Visitas, string>
    {
        private readonly ClubMan.Shared.Model.Visitas _document;
        private readonly string _id;
        private readonly System.Collections.Generic.Dictionary<string, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;
        private readonly string _tenantId;

        public InsertVisitasOperation135058755(ClubMan.Shared.Model.Visitas document, string id, System.Collections.Generic.Dictionary<string, System.Guid> versions, Marten.Schema.DocumentMapping mapping, string tenantId) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
            _tenantId = tenantId;
        }


        public const string COMMAND_TEXT = "select public.mt_insert_visitas(?, ?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Text;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, ClubMan.Shared.Model.Visitas document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Text;

            if (document.Id != null)
            {
                parameters[2].Value = document.Id;
            }

            else
            {
                parameters[2].Value = System.DBNull.Value;
            }

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

    // END: InsertVisitasOperation135058755
    
    
    // START: UpdateVisitasOperation135058755
    public class UpdateVisitasOperation135058755 : Marten.Internal.Operations.StorageOperation<ClubMan.Shared.Model.Visitas, string>
    {
        private readonly ClubMan.Shared.Model.Visitas _document;
        private readonly string _id;
        private readonly System.Collections.Generic.Dictionary<string, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;
        private readonly string _tenantId;

        public UpdateVisitasOperation135058755(ClubMan.Shared.Model.Visitas document, string id, System.Collections.Generic.Dictionary<string, System.Guid> versions, Marten.Schema.DocumentMapping mapping, string tenantId) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
            _tenantId = tenantId;
        }


        public const string COMMAND_TEXT = "select public.mt_update_visitas(?, ?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Text;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, ClubMan.Shared.Model.Visitas document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Text;

            if (document.Id != null)
            {
                parameters[2].Value = document.Id;
            }

            else
            {
                parameters[2].Value = System.DBNull.Value;
            }

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

    // END: UpdateVisitasOperation135058755
    
    
    // START: QueryOnlyVisitasSelector135058755
    public class QueryOnlyVisitasSelector135058755 : Marten.Internal.CodeGeneration.DocumentSelectorWithOnlySerializer, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.Visitas>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public QueryOnlyVisitasSelector135058755(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.Visitas Resolve(System.Data.Common.DbDataReader reader)
        {

            ClubMan.Shared.Model.Visitas document;
            document = _serializer.FromJson<ClubMan.Shared.Model.Visitas>(reader, 0);
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.Visitas> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {

            ClubMan.Shared.Model.Visitas document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.Visitas>(reader, 0, token).ConfigureAwait(false);
            return document;
        }

    }

    // END: QueryOnlyVisitasSelector135058755
    
    
    // START: LightweightVisitasSelector135058755
    public class LightweightVisitasSelector135058755 : Marten.Internal.CodeGeneration.DocumentSelectorWithVersions<ClubMan.Shared.Model.Visitas, string>, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.Visitas>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public LightweightVisitasSelector135058755(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.Visitas Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<string>(0);

            ClubMan.Shared.Model.Visitas document;
            document = _serializer.FromJson<ClubMan.Shared.Model.Visitas>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.Visitas> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<string>(0, token);

            ClubMan.Shared.Model.Visitas document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.Visitas>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }

    }

    // END: LightweightVisitasSelector135058755
    
    
    // START: IdentityMapVisitasSelector135058755
    public class IdentityMapVisitasSelector135058755 : Marten.Internal.CodeGeneration.DocumentSelectorWithIdentityMap<ClubMan.Shared.Model.Visitas, string>, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.Visitas>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public IdentityMapVisitasSelector135058755(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.Visitas Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<string>(0);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.Visitas document;
            document = _serializer.FromJson<ClubMan.Shared.Model.Visitas>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.Visitas> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<string>(0, token);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.Visitas document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.Visitas>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }

    }

    // END: IdentityMapVisitasSelector135058755
    
    
    // START: DirtyTrackingVisitasSelector135058755
    public class DirtyTrackingVisitasSelector135058755 : Marten.Internal.CodeGeneration.DocumentSelectorWithDirtyChecking<ClubMan.Shared.Model.Visitas, string>, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.Visitas>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public DirtyTrackingVisitasSelector135058755(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.Visitas Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<string>(0);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.Visitas document;
            document = _serializer.FromJson<ClubMan.Shared.Model.Visitas>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.Visitas> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<string>(0, token);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.Visitas document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.Visitas>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }

    }

    // END: DirtyTrackingVisitasSelector135058755
    
    
    // START: QueryOnlyVisitasDocumentStorage135058755
    public class QueryOnlyVisitasDocumentStorage135058755 : Marten.Internal.Storage.QueryOnlyDocumentStorage<ClubMan.Shared.Model.Visitas, string>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public QueryOnlyVisitasDocumentStorage135058755(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override string AssignIdentity(ClubMan.Shared.Model.Visitas document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (string.IsNullOrEmpty(document.Id)) throw new InvalidOperationException("Id/id values cannot be null or empty");
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.Visitas document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateVisitasOperation135058755
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Visitas, string>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.Visitas document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertVisitasOperation135058755
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Visitas, string>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.Visitas document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertVisitasOperation135058755
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Visitas, string>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.Visitas document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override string Identity(ClubMan.Shared.Model.Visitas document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.QueryOnlyVisitasSelector135058755(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(string id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id).With(TenantIdArgument.ArgName, tenant);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.String[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids).With(TenantIdArgument.ArgName, tenant);
        }

    }

    // END: QueryOnlyVisitasDocumentStorage135058755
    
    
    // START: LightweightVisitasDocumentStorage135058755
    public class LightweightVisitasDocumentStorage135058755 : Marten.Internal.Storage.LightweightDocumentStorage<ClubMan.Shared.Model.Visitas, string>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public LightweightVisitasDocumentStorage135058755(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override string AssignIdentity(ClubMan.Shared.Model.Visitas document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (string.IsNullOrEmpty(document.Id)) throw new InvalidOperationException("Id/id values cannot be null or empty");
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.Visitas document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateVisitasOperation135058755
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Visitas, string>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.Visitas document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertVisitasOperation135058755
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Visitas, string>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.Visitas document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertVisitasOperation135058755
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Visitas, string>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.Visitas document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override string Identity(ClubMan.Shared.Model.Visitas document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.LightweightVisitasSelector135058755(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(string id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id).With(TenantIdArgument.ArgName, tenant);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.String[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids).With(TenantIdArgument.ArgName, tenant);
        }

    }

    // END: LightweightVisitasDocumentStorage135058755
    
    
    // START: IdentityMapVisitasDocumentStorage135058755
    public class IdentityMapVisitasDocumentStorage135058755 : Marten.Internal.Storage.IdentityMapDocumentStorage<ClubMan.Shared.Model.Visitas, string>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public IdentityMapVisitasDocumentStorage135058755(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override string AssignIdentity(ClubMan.Shared.Model.Visitas document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (string.IsNullOrEmpty(document.Id)) throw new InvalidOperationException("Id/id values cannot be null or empty");
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.Visitas document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateVisitasOperation135058755
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Visitas, string>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.Visitas document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertVisitasOperation135058755
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Visitas, string>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.Visitas document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertVisitasOperation135058755
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Visitas, string>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.Visitas document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override string Identity(ClubMan.Shared.Model.Visitas document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.IdentityMapVisitasSelector135058755(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(string id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id).With(TenantIdArgument.ArgName, tenant);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.String[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids).With(TenantIdArgument.ArgName, tenant);
        }

    }

    // END: IdentityMapVisitasDocumentStorage135058755
    
    
    // START: DirtyTrackingVisitasDocumentStorage135058755
    public class DirtyTrackingVisitasDocumentStorage135058755 : Marten.Internal.Storage.DirtyCheckedDocumentStorage<ClubMan.Shared.Model.Visitas, string>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public DirtyTrackingVisitasDocumentStorage135058755(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override string AssignIdentity(ClubMan.Shared.Model.Visitas document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (string.IsNullOrEmpty(document.Id)) throw new InvalidOperationException("Id/id values cannot be null or empty");
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.Visitas document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateVisitasOperation135058755
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Visitas, string>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.Visitas document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertVisitasOperation135058755
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Visitas, string>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.Visitas document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertVisitasOperation135058755
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.Visitas, string>(),
                _document
                , tenant
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.Visitas document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override string Identity(ClubMan.Shared.Model.Visitas document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.DirtyTrackingVisitasSelector135058755(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(string id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id).With(TenantIdArgument.ArgName, tenant);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.String[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids).With(TenantIdArgument.ArgName, tenant);
        }

    }

    // END: DirtyTrackingVisitasDocumentStorage135058755
    
    
    // START: VisitasBulkLoader135058755
    public class VisitasBulkLoader135058755 : Marten.Internal.CodeGeneration.BulkLoader<ClubMan.Shared.Model.Visitas, string>
    {
        private readonly Marten.Internal.Storage.IDocumentStorage<ClubMan.Shared.Model.Visitas, string> _storage;

        public VisitasBulkLoader135058755(Marten.Internal.Storage.IDocumentStorage<ClubMan.Shared.Model.Visitas, string> storage) : base(storage)
        {
            _storage = storage;
        }


        public const string MAIN_LOADER_SQL = "COPY public.mt_doc_visitas(\"mt_dotnet_type\", \"id\", \"mt_version\", \"tenant_id\", \"data\") FROM STDIN BINARY";

        public const string TEMP_LOADER_SQL = "COPY mt_doc_visitas_temp(\"mt_dotnet_type\", \"id\", \"mt_version\", \"tenant_id\", \"data\") FROM STDIN BINARY";

        public const string COPY_NEW_DOCUMENTS_SQL = "insert into public.mt_doc_visitas (\"id\", \"tenant_id\", \"data\", \"mt_version\", \"mt_dotnet_type\", mt_last_modified) (select mt_doc_visitas_temp.\"id\", mt_doc_visitas_temp.\"tenant_id\", mt_doc_visitas_temp.\"data\", mt_doc_visitas_temp.\"mt_version\", mt_doc_visitas_temp.\"mt_dotnet_type\", transaction_timestamp() from mt_doc_visitas_temp left join public.mt_doc_visitas on mt_doc_visitas_temp.id = public.mt_doc_visitas.id where public.mt_doc_visitas.id is null)";

        public const string OVERWRITE_SQL = "update public.mt_doc_visitas target SET tenant_id = source.tenant_id, data = source.data, mt_version = source.mt_version, mt_dotnet_type = source.mt_dotnet_type, mt_last_modified = transaction_timestamp() FROM mt_doc_visitas_temp source WHERE source.id = target.id";

        public const string CREATE_TEMP_TABLE_FOR_COPYING_SQL = "create temporary table mt_doc_visitas_temp as select * from public.mt_doc_visitas limit 0";


        public override void LoadRow(Npgsql.NpgsqlBinaryImporter writer, ClubMan.Shared.Model.Visitas document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer)
        {
            writer.Write(document.GetType().FullName, NpgsqlTypes.NpgsqlDbType.Varchar);
            writer.Write(document.Id, NpgsqlTypes.NpgsqlDbType.Text);
            writer.Write(Marten.Schema.Identity.CombGuidIdGeneration.NewGuid(), NpgsqlTypes.NpgsqlDbType.Uuid);
            writer.Write(tenant.TenantId, NpgsqlTypes.NpgsqlDbType.Varchar);
            writer.Write(serializer.ToJson(document), NpgsqlTypes.NpgsqlDbType.Jsonb);
        }


        public override async System.Threading.Tasks.Task LoadRowAsync(Npgsql.NpgsqlBinaryImporter writer, ClubMan.Shared.Model.Visitas document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer, System.Threading.CancellationToken cancellation)
        {
            await writer.WriteAsync(document.GetType().FullName, NpgsqlTypes.NpgsqlDbType.Varchar, cancellation);
            await writer.WriteAsync(document.Id, NpgsqlTypes.NpgsqlDbType.Text, cancellation);
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

    // END: VisitasBulkLoader135058755
    
    
    // START: VisitasProvider135058755
    public class VisitasProvider135058755 : Marten.Internal.Storage.DocumentProvider<ClubMan.Shared.Model.Visitas>
    {
        private readonly Marten.Schema.DocumentMapping _mapping;

        public VisitasProvider135058755(Marten.Schema.DocumentMapping mapping) : base(new VisitasBulkLoader135058755(new QueryOnlyVisitasDocumentStorage135058755(mapping)), new QueryOnlyVisitasDocumentStorage135058755(mapping), new LightweightVisitasDocumentStorage135058755(mapping), new IdentityMapVisitasDocumentStorage135058755(mapping), new DirtyTrackingVisitasDocumentStorage135058755(mapping))
        {
            _mapping = mapping;
        }


    }

    // END: VisitasProvider135058755
    
    
}

